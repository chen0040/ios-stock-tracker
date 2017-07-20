//
//  NewsPageViewController.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "NewsArticle.h"

@interface NewsPageViewController : UIViewController {
    IBOutlet UIBarButtonItem *btnDone;
    IBOutlet UILabel *compLabel;
    IBOutlet UILabel *dateLabel;
    IBOutlet UILabel *titleLabel;
    IBOutlet UIWebView *webView;
	NewsArticle* newsArticle;
	
}
@property (assign) UILabel* compLabel;
@property (assign) UILabel* dateLabel;
@property (assign) UILabel* titleLabel;

- (IBAction)doneReading:(UIBarButtonItem *)sender;

@property (retain) NewsArticle* newsArticle;
-(id)initWithNewsArticle: (NewsArticle*) article;
@end
