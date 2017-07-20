//
//  PricePageViewController.m
//
//  Created by chen on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "PricePageViewController.h"
#import "PricePlotViewController.h"

@implementation PricePageViewController
@synthesize volLabel;
@synthesize codeLabel;
@synthesize dayValLabel;
@synthesize bestBuyLabel;
@synthesize bestSellLabel;
@synthesize buyVolLabel;
@synthesize sellVolLabel;
@synthesize dayHighLabel;
@synthesize dayLowLabel;
@synthesize openValLabel;
@synthesize closeValLabel;
@synthesize codeTypeLabel;
@synthesize chgImg;
@synthesize price;
@synthesize chgLabel;

- (IBAction)close:(UIBarButtonItem *)sender {
    [self.parentViewController dismissModalViewControllerAnimated:YES];
}

-(id) initWithPrice: (Price*) _price
{
	self=[super init];
	if(!self) return nil;
	self.price=_price;
	
	return self;
}

-(void) segmentAction: (UISegmentedControl *) sender
{
	//int index=sender.selectedSegmentIndex;
	
	[self reloadData];
}

-(void) reloadData
{
	
}

-(void) addSegmentedControl: (CGRect) frame
{
	// Create the segmented control. Choose one of the three styles
	NSArray *buttonNames = [NSArray arrayWithObjects:@"1d", @"2d", @"5d", @"10d", @"3m", @"6m", @"1y", @"5y", nil];
	segmentedControl = [[UISegmentedControl alloc] initWithItems:buttonNames];
	segmentedControl.segmentedControlStyle = UISegmentedControlStyleBar; 
	[segmentedControl setTintColor:[UIColor darkGrayColor]];
	[segmentedControl addTarget:self action:@selector(segmentAction:) forControlEvents:UIControlEventValueChanged];
	segmentedControl.frame=frame;
	segmentedControl.momentary = NO;
	segmentedControl.selectedSegmentIndex = 0;
	segmentedControl.tintColor=[UIColor colorWithRed:0.0f green:0.4f blue:0.0f alpha:0.3f];
	
	// Add it to the navigation bar
	[self.view addSubview:segmentedControl];
	[segmentedControl release];
}

-(void)loadView
{
	self.view=[[[NSBundle mainBundle] loadNibNamed:@"PricePageViewController" owner:self options:nil] lastObject];
	
	float y=260;
	float height=30.0f;
	float width=320.0f;
	
	[self addSegmentedControl:CGRectMake(10.0f, y, width-20.0f, height)];
	
	y+=height;
	height=480.0f - y;
	[self addPlotControl: CGRectMake(5.0f, y, width-10.0f, height-5.0f)];
}

-(void) addPlotControl: (CGRect) frame
{
	PricePlotViewController* ppvc=[[PricePlotViewController alloc] init];
	ppvc.view.frame=frame;
	ppvc.view.backgroundColor=[UIColor colorWithRed:0.0f green:0.1f blue:0.0f alpha:1.0];
	[self.view addSubview:ppvc.view];
}

-(void) viewDidLoad
{
	[super viewDidLoad];
	self.codeLabel.text = self.price.code;
	self.codeTypeLabel.text=self.price.codeType;
	self.volLabel.text=[NSString stringWithFormat:@"%d", (int)self.price.vol];
	self.dayValLabel.text=[NSString stringWithFormat:@"%.2f", self.price.dayHigh];
	self.bestBuyLabel.text=[NSString stringWithFormat:@"%.2f", self.price.bestBuy];
	self.bestSellLabel.text=[NSString stringWithFormat:@"%.2f", self.price.bestSell];
	self.buyVolLabel.text=[NSString stringWithFormat:@"%d", (int)self.price.buyVol];
	self.sellVolLabel.text=[NSString stringWithFormat:@"%d", (int)self.price.sellVol];
	self.dayHighLabel.text=[NSString stringWithFormat:@"%.2f", self.price.dayHigh];
	self.dayLowLabel.text=[NSString stringWithFormat:@"%.2f", self.price.dayLow];
	self.openValLabel.text=[NSString stringWithFormat:@"%.2f", self.price.openValue];
	self.closeValLabel.text=[NSString stringWithFormat:@"%.2f", self.price.closeValue];
	
	
	if (self.price.chg==0) {
		[self.chgImg setImage:[UIImage imageNamed:@"balanced_arrow.png"]];
		self.chgLabel.textColor=[UIColor whiteColor];
		self.chgLabel.text=[NSString stringWithFormat:@"%.2f(%.2f%%)", self.price.chg, self.price.chgP];
	}
	else if(self.price.chg > 0)
	{
		[self.chgImg setImage:[UIImage imageNamed:@"up_arrow.png"]];
		self.chgLabel.textColor=[UIColor greenColor];
		self.chgLabel.text=[NSString stringWithFormat:@"+%.2f(+%.2f%%)", self.price.chg, self.price.chgP];
	}
	else {
		[self.chgImg setImage:[UIImage imageNamed:@"down_arrow.png"]];
		self.chgLabel.textColor=[UIColor redColor];
		self.chgLabel.text=[NSString stringWithFormat:@"%.2f(%.2f%%)", self.price.chg, self.price.chgP];
	}
	
}
@end
