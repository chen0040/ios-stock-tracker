//
//  Price.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <Foundation/Foundation.h>


@interface Price : NSObject {
	NSString* code;
	NSString* codeType;
	double lastDone;
	double dayHigh;
	double dayLow;
	double bestBuy;
	double bestSell;
	double vol;
	double chg;
	double chgP;
	double buyVol;
	double sellVol;
	double openValue;
	double closeValue;
	int cellRow;
}

@property (retain) NSString* code;
@property (retain) NSString* codeType;
@property double lastDone;
@property double dayHigh;
@property double dayLow;
@property double bestBuy;
@property double bestSell;
@property double vol;
@property double chg;
@property double chgP;
@property double buyVol;
@property double sellVol;
@property double openValue;
@property double closeValue;
@property int cellRow;

-(NSString*) toJson;
-(id) initWithCode:(NSString *)_code type:(NSString *)_type;
-(id) initWithDictionary: (NSDictionary*) dict;

@end
