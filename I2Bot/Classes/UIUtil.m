//
//  UIUtil.m
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "UIUtil.h"


@implementation UIUtil
+(void) showAlert:(NSString *)message
{
	UIAlertView* av=[[[UIAlertView alloc] initWithTitle:message message:nil delegate:nil cancelButtonTitle:@"OK" otherButtonTitles:nil] autorelease];
	[av show];
}
@end
