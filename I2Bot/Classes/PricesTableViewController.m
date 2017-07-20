//
//  PricesTableViewController.m
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "PricesTableViewController.h"
#import "PriceManager.h"
#import "PriceTableViewCell.h"
#import "PricePageViewController.h"
#import "Util/UIUtil.h"

@implementation PricesTableViewController
@synthesize navController;


-(id) init
{
	self=[super init];
	if(!self) return nil;
	return self;
}

-(void) loadView
{
	[super loadView];
	self.tableView.backgroundColor=[UIColor blackColor];
	self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
}

- (NSInteger)numberOfSectionsInTableView:(UITableView *)aTableView 
{ 
	return 1; 
}

- (NSInteger)tableView:(UITableView *)aTableView numberOfRowsInSection:(NSInteger)section 
{
	return [[PriceManager sharedInstance] getPriceCount];
}

- (UITableViewCell *)tableView:(UITableView *)tView cellForRowAtIndexPath:(NSIndexPath *)indexPath
{
	// Retrieve or create a cell
	PriceTableViewCell *cell = (PriceTableViewCell*)[tView dequeueReusableCellWithIdentifier:[PriceManager sharedInstance].codeType];
	if (!cell) 
	{
		cell = [[[NSBundle mainBundle] loadNibNamed:@"PriceTableViewCell" owner:self options:nil] lastObject];
		//[[[UITableViewCell alloc] initWithStyle:style reuseIdentifier:[PriceManager sharedInstance].codeType] autorelease];
	}
	
	// Set cell label
	//NSString *aKey = [@"Row " stringByAppendingString:[ALPHA objectAtIndex:indexPath.row]];
	
	PriceManager* pm=[PriceManager sharedInstance];
	Price* _price=[pm getPrice: indexPath.row];
	cell.codeLabel.text = _price.code;
	cell.volLabel.text=[NSString stringWithFormat:@"%d", (int)_price.vol];
	cell.dayValLabel.text=[NSString stringWithFormat:@"%.2f", _price.dayHigh];
	cell.bestBuyLabel.text=[NSString stringWithFormat:@"%.2f", _price.bestBuy];
	cell.bestSellLabel.text=[NSString stringWithFormat:@"%.2f", _price.bestSell];
	cell.buyVolLabel.text=[NSString stringWithFormat:@"%d", (int)_price.buyVol];
	cell.sellVolLabel.text=[NSString stringWithFormat:@"%d", (int)_price.sellVol];
	cell.dayHighLabel.text=[NSString stringWithFormat:@"%.2f", _price.dayHigh];
	cell.dayLowLabel.text=[NSString stringWithFormat:@"%.2f", _price.dayLow];
	
	
	if (_price.chg==0) {
		[cell.chgImg setImage:[UIImage imageNamed:@"balanced_arrow.png"]];
		cell.chgLabel.textColor=[UIColor whiteColor];
		cell.chgLabel.text=[NSString stringWithFormat:@"%.2f(%.2f%%)", _price.chg, _price.chgP];
	}
	else if(_price.chg > 0)
	{
		[cell.chgImg setImage:[UIImage imageNamed:@"up_arrow.png"]];
		cell.chgLabel.textColor=[UIColor greenColor];
		cell.chgLabel.text=[NSString stringWithFormat:@"+%.2f(+%.2f%%)", _price.chg, _price.chgP];
	}
	else {
		[cell.chgImg setImage:[UIImage imageNamed:@"down_arrow.png"]];
		cell.chgLabel.textColor=[UIColor redColor];
		cell.chgLabel.text=[NSString stringWithFormat:@"%.2f(%.2f%%)", _price.chg, _price.chgP];
	}

	
	
	/* Used to create Figure 11-11
	 if (indexPath.row % 2)
	 cell.accessoryType = UITableViewCellAccessoryDetailDisclosureButton;
	 else
	 cell.accessoryType = UITableViewCellAccessoryDisclosureIndicator;
	 */
	
	cell.accessoryType = UITableViewCellAccessoryDetailDisclosureButton;
	cell.editingAccessoryType = UITableViewCellAccessoryNone;
	
	return cell;
}

- (CGFloat) tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
	PriceManager* pm=[PriceManager sharedInstance];
	Price* _price=[pm getPrice: indexPath.row];

	if(_price.cellRow==1)
	{
		return 44;
	}
	else {
		return 76;
	}

}

// Respond to accessory button taps
-(void)tableView:(UITableView *)tableView accessoryButtonTappedForRowWithIndexPath:(NSIndexPath *)indexPath
{
	PriceManager* pm=[PriceManager sharedInstance];
	PricePageViewController* ppv=[[[PricePageViewController alloc] initWithPrice:[pm getPrice: indexPath.row]] autorelease];
	
	[self.navController presentModalViewController:ppv animated:YES];
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)newIndexPath
{
	PriceManager* pm=[PriceManager sharedInstance];
	Price* _price=[pm getPrice: newIndexPath.row];

	[self.tableView beginUpdates];

		
	if(_price.cellRow==1)
	{
		_price.cellRow=2;
		[self.tableView deleteRowsAtIndexPaths:[NSArray arrayWithObject: newIndexPath] withRowAnimation:UITableViewRowAnimationFade];
		[self.tableView insertRowsAtIndexPaths:[NSArray arrayWithObject: newIndexPath] withRowAnimation:UITableViewRowAnimationFade];
	}
	else {
		_price.cellRow=1;
		[self.tableView deleteRowsAtIndexPaths:[NSArray arrayWithObject: newIndexPath] withRowAnimation:UITableViewRowAnimationMiddle];
		[self.tableView insertRowsAtIndexPaths:[NSArray arrayWithObject: newIndexPath] withRowAnimation:UITableViewRowAnimationFade];
	}
		
	
	[self.tableView endUpdates];
}
@end
