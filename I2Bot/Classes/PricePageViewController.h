//
//  PricePageViewController.h
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Price.h"

@interface PricePageViewController : UIViewController {
    IBOutlet UIBarButtonItem *btnClose;
    IBOutlet UILabel *bestBuyLabel;
    IBOutlet UILabel *bestSellLabel;
    IBOutlet UILabel *buyVolLabel;
    IBOutlet UILabel *closeValLabel;
    IBOutlet UILabel *dayHighLabel;
    IBOutlet UILabel *dayLowLabel;
    IBOutlet UILabel *openValLabel;
    IBOutlet UILabel *sellVolLabel;
    IBOutlet UILabel *volLabel;
    IBOutlet UIImageView *chgImg;
    IBOutlet UILabel *codeLabel;
    IBOutlet UILabel *codeTypeLabel;
    IBOutlet UILabel *dayValLabel;
    IBOutlet UILabel *chgLabel;
	Price* price;
	UISegmentedControl* segmentedControl;
}
@property (assign) UILabel* codeLabel;
@property (assign) UILabel* volLabel;
@property (assign) UILabel* dayValLabel;
@property (assign) UILabel* bestBuyLabel;
@property (assign) UILabel* bestSellLabel;
@property (assign) UILabel* buyVolLabel;
@property (assign) UILabel* sellVolLabel;
@property (assign) UILabel* dayHighLabel;
@property (assign) UILabel* dayLowLabel;
@property (assign) UILabel* openValLabel;
@property (assign) UILabel* closeValLabel;
@property (assign) UIImageView* chgImg;
@property (assign) UILabel* codeTypeLabel;
@property (retain) Price* price;
@property (assign) UILabel* chgLabel;

- (id)initWithPrice:(Price *)_price;
- (IBAction)close:(UIBarButtonItem *)sender;
-(void) reloadData;
-(void) addSegmentedControl:(CGRect)frame;
-(void) addPlotControl:(CGRect)frame;
@end
