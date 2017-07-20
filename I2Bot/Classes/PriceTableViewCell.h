//
//  PriceTableViewCell.h
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Foundation/Foundation.h>

@interface PriceTableViewCell : UITableViewCell {
    IBOutlet UILabel *codeLabel;
    IBOutlet UILabel *volLabel;
    IBOutlet UILabel *dayValLabel;
    IBOutlet UILabel *bestBuyLabel;
    IBOutlet UILabel *bestSellLabel;
    IBOutlet UILabel *buyVolLabel;
    IBOutlet UILabel *dayHighLabel;
    IBOutlet UILabel *dayLowLabel;
    IBOutlet UILabel *sellVolLabel;
    IBOutlet UIImageView *chgImg;
    IBOutlet UILabel *chgLabel;
	
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
@property (assign) UIImageView* chgImg;
@property (assign) UILabel* chgLabel;


@end
