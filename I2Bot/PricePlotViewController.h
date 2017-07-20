//
//  PricePlotViewController.h
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "CorePlot-CocoaTouch.h"

@interface PricePlotViewController : UIViewController<CPPlotDataSource> {
	CPXYGraph *graph;
}

@end
