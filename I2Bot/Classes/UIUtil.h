//
//  UIUtil.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/23/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>

#define UIBARBUTTON(TITLE, SELECTOR) 	[[[UIBarButtonItem alloc] initWithTitle:TITLE style:UIBarButtonItemStylePlain target:self action:SELECTOR] autorelease]
#define UIIMGBARBUTTON(IMAGE, SELECTOR) [[[UIBarButtonItem alloc] initWithImage:IMAGE style:UIBarButtonItemStylePlain target:self action:SELECTOR] autorelease]
#define UISYSBARBUTTON(ITEM, SELECTOR) [[[UIBarButtonItem alloc] initWithBarButtonSystemItem:ITEM target:self action:SELECTOR] autorelease]
#define UICUSTOMBARBUTTON(VIEW) [[[UIBarButtonItem alloc] initWithCustomView:VIEW] autorelease]

@interface UIUtil : NSObject {

}
+(void) showAlert: (NSString*) message;
@end
