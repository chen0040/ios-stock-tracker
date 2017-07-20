//
//  PricesViewController.m
//  Fresh7
//
//  Created by chen on 1/21/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "PricesViewController.h"
#import "Util/UIUtil.h"
#import "PriceManager.h"

@implementation PricesViewController
@synthesize tvc;

-(void) loadFromUrl: (NSString*)url_text
{
	responseData = [[NSMutableData data] retain];		
	NSURLRequest *request = [NSURLRequest requestWithURL:[NSURL URLWithString: url_text]];
	[[NSURLConnection alloc] initWithRequest:request delegate:self];
}

- (void)connection:(NSURLConnection *)connection didReceiveResponse:(NSURLResponse *)response {
	[responseData setLength:0];
}

- (void)connection:(NSURLConnection *)connection didReceiveData:(NSData *)data {
	[responseData appendData:data];
}

- (void)connection:(NSURLConnection *)connection didFailWithError:(NSError *)error {
	[UIUtil showAlert: [NSString stringWithFormat:@"Connection failed: %@", [error description]]];
}

-(void) reloadData
{
	PriceManager* pm=[PriceManager sharedInstance];
	[self loadFromUrl: [NSString stringWithFormat: @"http://www.czcodezone.com/quote/price.php?startrowindex=%d&rowcount=%d&quotetype=%@", pm.pageIndex * pm.pageSize, pm.pageSize, pm.codeType]];
	
}

- (void)connectionDidFinishLoading:(NSURLConnection *)connection {		
	[connection release];
	
	NSString *responseString = [[NSString alloc] initWithData:responseData encoding:NSUTF8StringEncoding];
	[responseData release];
	
	//[self showAlert: responseString];
	//[responseString release];
	
	[[PriceManager sharedInstance] reloadData: responseString];
	[responseString release];
	
	[self dataDidReload];
}

-(id)init
{
	self=[super init];
	if(!self) return nil;
	[self.tabBarItem initWithTitle:@"Prices" image:[UIImage imageNamed:@"tabbar_prices.png"] tag:0];
	return self;
}

-(void) viewDidLoad
{
	[super viewDidLoad];
}

-(void) segmentAction: (UISegmentedControl *) sender
{
	int index=sender.selectedSegmentIndex;
	PriceManager* pm=[PriceManager sharedInstance];
	NSString* codeType=@"All";
	
	switch (index) {
		case 1:
			codeType=@"Stocks";
			break;
		case 2:
			codeType=@"Warrants";
			break;
		case 3:
			codeType=@"ETF";
			break;
		case 4:
			codeType=@"ES";
			break;
		case 5:
			codeType=@"ADR";
			break;
		default:
			codeType=@"All";
			break;
	}
	pm.pageIndex=0;
	pm.codeType=codeType;
	[self reloadData];
}

-(void)dataDidReload
{
	[self.tvc.tableView reloadData];
	PriceManager* pm=[PriceManager sharedInstance];
	page_header.text=[NSString stringWithFormat:@"%d / %d",  pm.pageIndex+1, pm.pageCount];
}

-(void)nextPage
{
	PriceManager* pm=[PriceManager sharedInstance];
	if(pm.pageIndex >= pm.pageCount-1)
	{
		return;
	}
	pm.pageIndex+=1;
	[self reloadData];
	
}

-(void)prevPage
{
	
	PriceManager* pm=[PriceManager sharedInstance];
	if(pm.pageIndex <= 0)
	{
		return;
	}
	pm.pageIndex-=1;
	[self reloadData];
}

-(void) action
{
	PriceManager* pm=[PriceManager sharedInstance];
	int code_count=[pm.code_entries count];
	NSMutableString* message=[NSMutableString stringWithString: @" codes: "];
	for(int i=0; i != code_count; ++i)
	{
		[message appendFormat:@"%@\n", [[pm.code_entries objectAtIndex:i] description]];
	}
	[UIUtil showAlert:message];
}

-(void)addToolBar: (CGRect) frame
{
	UIToolbar *tb = [[UIToolbar alloc] initWithFrame:frame];
	[tb setTintColor:[UIColor clearColor]];
	//tb.center = CGPointMake(160.0f, 200.0f);
	NSMutableArray *tbitems = [NSMutableArray array];
	
	//[tbitems addObject:UIIMGBARBUTTON([UIImage imageNamed:@"toolbar_toolbox.png"], @selector(action))];
	[tbitems addObject:UIIMGBARBUTTON([UIImage imageNamed:@"toolbar_wrench.png"], @selector(action))];
	[tbitems addObject:UIIMGBARBUTTON([UIImage imageNamed:@"toolbar_refresh.png"], @selector(refresh))];
	
	// Add fixed 20 pixel width
	UIBarButtonItem *bbi = [[[UIBarButtonItem alloc] initWithBarButtonSystemItem:UIBarButtonSystemItemFixedSpace target:nil action:nil] autorelease];
	bbi.width = 20.0f;
	[tbitems addObject:bbi];
	
	tb.tintColor=[UIColor colorWithRed:0.0f green:0.1f blue:0.0f alpha:0.3f];
	
	tb.items = tbitems;
	[self.view addSubview:tb];
	[tb release];
}

-(void)addToolBar2: (CGRect) frame
{
	UIToolbar *tb = [[UIToolbar alloc] initWithFrame:frame];
	[tb setTintColor:[UIColor clearColor]];
	//tb.center = CGPointMake(160.0f, 200.0f);
	NSMutableArray *tbitems = [NSMutableArray array];
	
	
	[tbitems addObject:UISYSBARBUTTON(101, @selector(prevPage))];
	page_header=[[[UILabel alloc] initWithFrame: CGRectMake(0.0f, 0.0f, 60.0f, 30.0f)] autorelease];
	page_header.backgroundColor=[UIColor clearColor];
	page_header.textAlignment=UITextAlignmentCenter;
	page_header.textColor=[UIColor colorWithRed: 0.0f green: 0.8f blue: 0.0f alpha: 1.0f];
	[tbitems addObject:UICUSTOMBARBUTTON(page_header)];
	[tbitems addObject:UISYSBARBUTTON(102, @selector(nextPage))];
	tb.tintColor=[UIColor colorWithRed:0.0f green:0.1f blue:0.0f alpha:0.3f];
	
	
	tb.items = tbitems;
	[self.view addSubview:tb];
	[tb release];
}

-(void) addSegmentedControl: (CGRect) frame
{
	// Create the segmented control. Choose one of the three styles
	NSArray *buttonNames = [NSArray arrayWithObjects:@"All", @"Stocks", @"Warrants", @"ETF", @"ES", @"ADR", nil];
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

-(void) addTableViewController: (CGRect) frame
{
	self.tvc=[[PricesTableViewController alloc] init];
	self.tvc.tableView.frame=frame;
	self.tvc.navController=self.navigationController;
	[self.view addSubview:self.tvc.tableView];
}

-(void) refresh
{
	[self reloadData];
}

-(void) showAlertBox
{
}

-(void)loadView
{
	self.view=[[[NSBundle mainBundle] loadNibNamed:@"PricesViewController" owner:self options:nil] lastObject];
	
	float width=320.0f;
	float y=44.0f;
	float height=30.0f;
	[self addToolBar: CGRectMake(0.0f, y, 190.0f, height)];
	[self addToolBar2:CGRectMake(190.0f, y, 130.0f, height)];
	
	y+=height;
	height=30.0f;
	[self addSegmentedControl: CGRectMake(0.0f, y, width, height)];
	
	y+=height;
	height=480.0 - 44.0f - 66.0f - 30.0f * 2;
	[self addTableViewController: CGRectMake(0.0f, y, width, height)];
	
	UIBarButtonItem* leftbutton=UICUSTOMBARBUTTON([[[UIImageView alloc] initWithImage:[UIImage imageNamed:@"i2bot.png"]] autorelease]);
	UIBarButtonItem* rightbutton=UIBARBUTTON(@"I Invest Alert", @selector(showAlertBox));

	//leftbutton.tintColor=[UIColor colorWithRed: 0.0f green: 0.5f blue: 0.0f alpha: 1.0f];
	self.navigationItem.leftBarButtonItem=leftbutton;
	self.navigationItem.rightBarButtonItem=rightbutton;
	
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
