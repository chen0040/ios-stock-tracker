//
//  PortfolioViewController.m
//  Fresh7
//
//  Created by chen on 1/21/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "PortfolioViewController.h"

@implementation PortfolioViewController
-(id) init
{
	self=[super init];
	if(!self) return nil;
	[self.tabBarItem initWithTitle:@"Portfolio" image:[UIImage imageNamed: @"tabbar_portfolio.png"] tag:0];
	return self;
}
-(void)loadView
{
	self.view=[[[NSBundle mainBundle] loadNibNamed:@"PortfolioViewController" owner:self options:nil] lastObject];
	self.title=@"Portfolio";
}

/*
 // The designated initializer.  Override if you create the controller programmatically and want to perform customization that is not appropriate for viewDidLoad.
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil {
    if ((self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil])) {
        // Custom initialization
    }
    return self;
}
*/

/*
// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad {
    [super viewDidLoad];
}
*/

/*
// Override to allow orientations other than the default portrait orientation.
- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    // Return YES for supported orientations
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}
*/

- (void)didReceiveMemoryWarning {
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

- (void)viewDidUnload {
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}


- (void)dealloc {
    [super dealloc];
}


@end
