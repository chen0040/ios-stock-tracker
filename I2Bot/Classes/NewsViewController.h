//
//  NewsViewController.h
//  Fresh7
//
//  Created by Foh Chuan Heng on 1/21/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NewsTableViewController.h"


@interface NewsViewController : UIViewController {
    UISegmentedControl* segmentedControl;
	UILabel* page_header;
	NewsTableViewController* tvc;
	NSMutableData *responseData;
}
@property (assign) NewsTableViewController* tvc;
-(void) dataDidReload;
-(void) loadFromUrl:(NSString *)url_text;
-(void) reloadData;
@end
