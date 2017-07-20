//
//  PriceManager.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Price.h"

@interface PriceManager : NSObject {
	NSMutableArray* code_entries;
	NSMutableDictionary* code_categories;
	NSString* codeType;
	int pageSize;
	int pageIndex;
	int pageCount;
}
@property (retain) NSMutableArray* code_entries;
@property (retain) NSMutableDictionary* code_categories;
@property (retain) NSString* codeType;
@property int pageSize;
@property int pageIndex;
@property int pageCount;

+(PriceManager*) sharedInstance;
-(id) init;
-(BOOL) save:(NSString *)content toFile:(NSString *)filepath;
-(void) dealloc;
-(int) getPriceCount;
-(Price*) getPrice: (int) index;
-(BOOL) reloadData: (NSString*) content;
@end
