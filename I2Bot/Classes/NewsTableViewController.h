//
//  NewsTableViewController.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/25/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>


@interface NewsTableViewController : UITableViewController {
	NSMutableData *responseData;
	UINavigationController* navController;
}
@property (retain) UINavigationController* navController;

@end

