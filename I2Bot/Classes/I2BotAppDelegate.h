//
//  I2BotAppDelegate.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PricesViewController.h"
#import "NewsViewController.h"
#import "PortfolioViewController.h"
#import "SupportViewController.h"

@interface I2BotAppDelegate : NSObject <UIApplicationDelegate, UITabBarControllerDelegate> {
    UIWindow *window;
	PricesViewController* viewcontroller_prices;
	PortfolioViewController* viewcontroller_portfolio;
	NewsViewController* viewcontroller_news;
	SupportViewController* viewcontroller_support;
}

@property (nonatomic, retain) IBOutlet UIWindow *window;

@end

