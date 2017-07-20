//
//  PriceManager.m
//  I2Bot
//
//  Created by chen on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "NewsArticleManager.h"
#import "JSON/JSON.h"
#import "Util/UIUtil.h"
#import "Price.h"

@implementation NewsArticleManager
@synthesize code_entries;
@synthesize code_categories;
@synthesize codeType;
@synthesize pageSize;
@synthesize pageIndex;
@synthesize pageCount;

static NewsArticleManager* sharedInstance=nil;

+(NewsArticleManager*) sharedInstance
{
	if(sharedInstance == nil)
	{
		sharedInstance=[[NewsArticleManager alloc] init];
	}
	return sharedInstance;
}

-(int) getNewsArticleCount
{
	return self.code_entries.count;
	
	/*
	if([self.codeType isEqualToString:@"All"])
	{
		return self.code_entries.count;
	}
	else {
		NSMutableArray* _obj = [self.code_categories objectForKey:self.codeType];
		if(_obj)
		{
			return _obj.count;
		}
		else {
			return 0;
		}
		
	}*/
}

-(BOOL) reloadData:(NSString *)content
{
	self.code_entries=[NSMutableArray array];
	self.code_categories=[NSMutableDictionary dictionary];
	[self.code_categories setObject:[NSMutableArray array] forKey:@"News1"];
	[self.code_categories setObject:[NSMutableArray array] forKey:@"News2"];
	[self.code_categories setObject:[NSMutableArray array] forKey:@"News3"];
	[self.code_categories setObject:[NSMutableArray array] forKey:@"News4"];
	[self.code_categories setObject:[NSMutableArray array] forKey:@"News5"];
	
	NSError *error;
	SBJSON *json = [[SBJSON new] autorelease];
	NSDictionary* codes = [json objectWithString:content error:&error];
	
	if (codes != nil)
	{
		/*
		 for(NSString* aKey in codes)
		 {
		 [code_entries addObject: aKey];			
		 }*/
		
		NSString* txtPageCount=[codes objectForKey:@"PageCount"];
		NSString* txtPageIndex=[codes objectForKey:@"PageIndex"];
		NSString* txtPageSize=[codes objectForKey:@"PageSize"];
		
		self.pageSize=[txtPageSize intValue];
		self.pageIndex=[txtPageIndex intValue];
		self.pageCount=[txtPageCount intValue];
		
		
		NSArray* code_array=[codes objectForKey: @"News"];
		if(code_array)
		{
			for(int i=0; i != [code_array count]; ++i)
			{
				NSDictionary* individual_code=[code_array objectAtIndex:i];
				
				
				NSString* SNo=[individual_code objectForKey:@"SNo"];
				if(SNo)
				{
					NewsArticle* _news=[[[NewsArticle alloc] initWithDictionary: individual_code] autorelease];
					[self.code_entries addObject: _news];
					
					/*
					NSString* type=[individual_code valueForKey:@"Type"];
					NSMutableArray* code_category=[self.code_categories objectForKey:type];
					if(code_category)
					{
						Price* _price2=[[[Price alloc] initWithDictionary: individual_code] autorelease];
						[code_category addObject:_price2];
					}*/
				}
			}	
		}
	}	
	else {
		[UIUtil showAlert:@"Failed to parse news.dat"];
	}
	return YES;
}

-(NewsArticle*) getNewsArticle: (int) index
{
	return [self.code_entries objectAtIndex:index];
	/*
	if([self.codeType isEqualToString:@"All"])
	{
		return [self.code_entries objectAtIndex:index];
	}
	else {
		NSMutableArray* _obj = [self.code_categories objectForKey:self.codeType];
		if(_obj)
		{
			return [_obj objectAtIndex:index];
		}
		else {
			return nil;
		}
		
	}*/
}

-(id) init
{
	self=[super init];
	if(!self) return nil;
	
	self.codeType=@"All";
	self.pageSize=20;
	self.pageCount=1;
	self.pageIndex=0;
	
	NSString* filepath=[NSHomeDirectory() stringByAppendingPathComponent: @"Documents/news.dat"];
	BOOL fileExists = [[NSFileManager defaultManager] fileExistsAtPath:filepath];
	BOOL overwrite=YES;
	if(overwrite==YES || fileExists == NO)
	{
		NSMutableString* default_content=[NSMutableString stringWithString: @"{"];
		[default_content appendFormat: @"\"PageCount\":\"%d\",\n", 1];
		[default_content appendFormat: @"\"PageIndex\":\"%d\",\n", 0];
		[default_content appendFormat: @"\"PageSize\":\"%d\",\n", 20];
		[default_content appendString: @"\"News\":[\n"];
		
		[default_content appendString: @"]}\n"];
		
		[self save:default_content toFile:filepath];
	}
	
	NSError *error;
	NSString* content=[NSString stringWithContentsOfFile: filepath encoding: NSUTF8StringEncoding error:&error];
	if(content)
	{
		[self reloadData:content];
	}
	
	
	return self;
}

-(BOOL) save: (NSString*) content toFile: (NSString*) filepath
{
	
	NSError* error;
	if(![content writeToFile:filepath atomically:YES encoding: NSUTF8StringEncoding error:&error])
	{
		return NO;
	}
	return YES;
}
-(void) dealloc
{
	code_entries=nil;
	code_categories=nil;
	[super dealloc];
}
@end
