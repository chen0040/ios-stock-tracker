//
//  NewsArticle.m
//  I2Bot
//
//  Created by chen on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "NewsArticle.h"


@implementation NewsArticle
@synthesize newsDate;
@synthesize newsTime;
@synthesize newsSNo;
@synthesize newsTitle;
@synthesize newsKey;
@synthesize newsCompany;
@synthesize newsSiblings;

-(id) initWithDictionary:(NSDictionary *)dict
{
	self=[super init];
	if(!self) return nil;
	
	self.newsDate=[dict objectForKey:@"Date"];
	self.newsTime=[dict objectForKey:@"Time"];
	self.newsTitle=[dict objectForKey:@"Title"];
	self.newsSNo=[dict objectForKey:@"SNo"];
	self.newsKey=[dict objectForKey:@"Key"];
	self.newsCompany=[dict objectForKey:@"Company"];
	self.newsSiblings=[dict objectForKey:@"Siblings"];
	return self;
}
@end
