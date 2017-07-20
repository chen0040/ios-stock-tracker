//
//  NewsPageViewController.m
//  I2Bot
//
//  Created by chen on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "NewsPageViewController.h"


@implementation NewsPageViewController
@synthesize newsArticle;
@synthesize dateLabel;
@synthesize compLabel;
@synthesize titleLabel;

- (IBAction)doneReading:(UIBarButtonItem *)sender {
    [self.parentViewController dismissModalViewControllerAnimated:YES];
}

-(id)initWithNewsArticle:(NewsArticle *)article
{
	self=[super init];
	if(!self) return nil;
	self.newsArticle=article;
	return self;
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


// Implement viewDidLoad to do additional setup after loading the view, typically from a nib.
- (void)viewDidLoad {
    [super viewDidLoad];
	self.titleLabel.text=self.newsArticle.newsTitle;
	self.dateLabel.text=[NSString stringWithFormat:@"Updated at %@ %@", self.newsArticle.newsDate, self.newsArticle.newsTime];
	self.compLabel.text=self.newsArticle.newsCompany;
	
	NSString *urlAddress = [NSString stringWithFormat: @"http://www.czcodezone.com/quote/newsdetail.php?key=%@", self.newsArticle.newsKey]; // @"http://www.google.com";
	
	//Create a URL object.
	NSURL *url = [NSURL URLWithString:urlAddress];
	
	//URL Requst Object
	NSURLRequest *requestObj = [NSURLRequest requestWithURL:url];
	
	//Load the request in the UIWebView.
	[webView loadRequest:requestObj];
}


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
