//
//  Price.m
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "Price.h"


@implementation Price
@synthesize code;
@synthesize codeType;
@synthesize lastDone;
@synthesize dayHigh;
@synthesize dayLow;
@synthesize bestBuy;
@synthesize bestSell;
@synthesize vol;
@synthesize chg;
@synthesize chgP;
@synthesize buyVol;
@synthesize sellVol;
@synthesize openValue;
@synthesize closeValue;
@synthesize cellRow;

-(NSString*) toJson
{
	return [NSString stringWithFormat: @"{\"Code\":\"%@\", \"Type\":\"%@\", \"LastDone\":\"%f\", \"DayHigh\":\"%f\", \"DayLow\":\"%f\", \"BestBuy\":\"%f\", \"BestSell\":\"%f\", \"Vol\":\"%f\", \"Chg\":\"%f\", \"ChgP\":\"%f\", \"BuyVol\":\"%f\", \"SellVol\":\"%f\", \"OpenVal\":\"%f\", \"CloseVal\":\"%f\", \"CellRow\":\"%d\"}\n",
			code,
			codeType,
			lastDone,
			dayHigh,
			dayLow,
			bestBuy,
			bestSell,
			vol,
			chg,
			chgP,
			buyVol,
			sellVol,
			openValue,
			closeValue,
			cellRow];
}

-(id) initWithCode: (NSString*) _code type: (NSString*) _type
{
	self=[super init];
	if(!self) return nil;
	self.code=_code;
	self.codeType=_type;
	self.lastDone=0;
	self.dayHigh=0;
	self.dayLow=0;
	self.bestBuy=0;
	self.bestSell=0;
	self.vol=0;
	self.chg=0;
	self.chgP=0;
	self.buyVol=0;
	self.sellVol=0;
	self.openValue=0;
	self.closeValue=0;
	self.cellRow=1;
	return self;
}

-(id) initWithDictionary: (NSDictionary*) dict
{
	self=[super init];
	if(!self) return nil;
	
	id obj=nil;
	
	self.code=[dict objectForKey:@"Code"];
	self.codeType=[dict objectForKey:@"Type"];
	self.lastDone=[(NSString*)[dict objectForKey:@"LastDone"] doubleValue];
	self.dayHigh=[(NSString*)[dict objectForKey:@"DayHigh"] doubleValue];
	self.dayLow=[(NSString*)[dict objectForKey:@"DayLow"] doubleValue];
	self.bestBuy=[(NSString*)[dict objectForKey:@"BestBuy"] doubleValue];
	self.bestSell=[(NSString*)[dict objectForKey:@"BestSell"] doubleValue];
	self.vol=[(NSString*)[dict objectForKey:@"Vol"] doubleValue];
	self.chg=[(NSString*)[dict objectForKey:@"Chg"] doubleValue];
	self.chgP=[(NSString*)[dict objectForKey:@"ChgP"] doubleValue];
	self.buyVol=[(NSString*)[dict objectForKey:@"BuyVol"] doubleValue];
	self.sellVol=[(NSString*)[dict objectForKey:@"SellVol"] doubleValue];
	self.openValue=[(NSString*)[dict objectForKey:@"OpenValue"] doubleValue];
	self.closeValue=[(NSString*)[dict objectForKey:@"CloseValue"] doubleValue];
	
	obj=[dict objectForKey:@"CellRow"];
	if(obj)
	{
		self.cellRow=[(NSString*)obj intValue];
	}
	if(self.cellRow==0)
	{
		self.cellRow=1;
	}
	return self;
}

-(NSString*) description
{
	return [NSString stringWithFormat:@"Code: %@ Type: %@", self.code, self.codeType];
}

@end
