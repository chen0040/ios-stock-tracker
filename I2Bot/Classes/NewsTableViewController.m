//
//  NewsTableViewController.m
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/25/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "NewsTableViewController.h"
#import "NewsArticleManager.h"
#import "NewsPageViewController.h"

@implementation NewsTableViewController
@synthesize navController;

-(void) loadView
{
	[super loadView];
	self.tableView.backgroundColor=[UIColor colorWithRed:0.0f green:0.2f blue:0.0f alpha:0.5f];
	self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)aTableView 
{ 
	return 1; 
}

- (NSInteger)tableView:(UITableView *)aTableView numberOfRowsInSection:(NSInteger)section 
{
	return [[NewsArticleManager sharedInstance] getNewsArticleCount];
}

- (UITableViewCell *)tableView:(UITableView *)tView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
	// Retrieve or create a cell
	UITableViewStyle style=UITableViewCellStyleSubtitle;
	UITableViewCell *cell = [tView dequeueReusableCellWithIdentifier:[NewsArticleManager sharedInstance].codeType];
	if (!cell) 
	{
		cell = [[[UITableViewCell alloc] initWithStyle:style reuseIdentifier:[NewsArticleManager sharedInstance].codeType] autorelease];
		cell.backgroundColor=[UIColor colorWithRed: 0.0f green: 0.4f blue: 0.0f alpha: 1.0f];
	}
	
	// Set cell label
	//NSString *aKey = [@"Row " stringByAppendingString:[ALPHA objectAtIndex:indexPath.row]];
	
	NewsArticleManager* nam=[NewsArticleManager sharedInstance];
	NewsArticle* _news=[nam getNewsArticle: indexPath.row];
	cell.textLabel.text = _news.newsTitle;
	cell.textLabel.textColor=[UIColor colorWithRed:0.0f green:1.0f blue:0.0f alpha:1.0f];
	cell.textLabel.font=[UIFont fontWithName:@"Arial" size:11];
	cell.textLabel.backgroundColor=[UIColor clearColor];
	cell.detailTextLabel.text=[NSString stringWithFormat:@"%@ %@: %@", _news.newsDate, _news.newsTime, _news.newsCompany];
	cell.detailTextLabel.textColor=[UIColor colorWithRed:0.0f green:0.7f blue:0.0f alpha:1.0f];
	cell.detailTextLabel.font=[UIFont fontWithName:@"Arial" size:9];
	cell.detailTextLabel.backgroundColor=[UIColor clearColor];
	
	cell.accessoryType = UITableViewCellAccessoryDisclosureIndicator;
	cell.editingAccessoryType = UITableViewCellAccessoryNone;
	
	
	return cell;
}

/*
- (CGFloat) tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
	return 44;
}*/

// Respond to accessory button taps
-(void)tableView:(UITableView *)tableView accessoryButtonTappedForRowWithIndexPath:(NSIndexPath *)indexPath
{
	
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)newIndexPath
{
	NewsArticleManager* nam=[NewsArticleManager sharedInstance];
	NewsPageViewController* npv=[[[NewsPageViewController alloc] initWithNewsArticle:[nam getNewsArticle: newIndexPath.row]] autorelease];
	
	[self.navController presentModalViewController:npv animated:YES];
}
@end
