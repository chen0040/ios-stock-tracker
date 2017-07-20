//
//  PricesViewController.h
//  Fresh7
//
//  Created by Foh Chuan Heng on 1/21/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PricesTableViewController.h"


@interface PricesViewController : UIViewController {
    UISegmentedControl* segmentedControl;
	UILabel* page_header;
	PricesTableViewController* tvc;
	NSMutableData *responseData;
}
@property (assign) PricesTableViewController* tvc;
-(void) dataDidReload;
-(void) loadFromUrl:(NSString *)url_text;
-(void) reloadData;
@end
