//
//  NewsArticle.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <Foundation/Foundation.h>


@interface NewsArticle : NSObject {
	NSString* newsTime;
	NSString* newsDate;
	NSString* newsSNo;
	NSString* newsKey;
	NSString* newsCompany;
	NSString* newsTitle;
	NSString* newsSiblings;
}
@property (retain) NSString* newsTime;
@property (retain) NSString* newsDate;
@property (retain) NSString* newsSNo;
@property (retain) NSString* newsKey;
@property (retain) NSString* newsCompany;
@property (retain) NSString* newsTitle;
@property (retain) NSString* newsSiblings;

-(id)initWithDictionary: (NSDictionary*) dict;

@end
