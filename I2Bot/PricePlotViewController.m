//
//  PricePlotViewController.m
//  I2Bot
//
//  Created by Foh Chuan Heng on 1/27/11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#import "PricePlotViewController.h"


@implementation PricePlotViewController

/*
 // The designated initializer.  Override if you create the controller programmatically and want to perform customization that is not appropriate for viewDidLoad.
- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil {
    if ((self = [super initWithNibName:nibNameOrNil bundle:nibBundleOrNil])) {
        // Custom initialization
    }
    return self;
}
*/

- (void)viewDidLoad {
	[super viewDidLoad];
	
	graph = [[CPXYGraph alloc] initWithFrame: self.view.bounds];
	
	CPGraphHostingView *hostingView = (CPGraphHostingView *)self.view;
	hostingView.hostedGraph = graph;
	graph.paddingLeft = 20.0;
	graph.paddingTop = 20.0;
	graph.paddingRight = 20.0;
	graph.paddingBottom = 20.0;
	
	CPXYPlotSpace *plotSpace = (CPXYPlotSpace *)graph.defaultPlotSpace;
	plotSpace.xRange = [CPPlotRange plotRangeWithLocation:CPDecimalFromFloat(0) 
												   length:CPDecimalFromFloat(24)];
	plotSpace.yRange = [CPPlotRange plotRangeWithLocation:CPDecimalFromFloat(0) 
												   length:CPDecimalFromFloat(30)];
	
	CPXYAxisSet *axisSet = (CPXYAxisSet *)graph.axisSet;
	
	CPLineStyle *lineStyle = [CPLineStyle lineStyle];
	lineStyle.lineColor = [CPColor greenColor];
	lineStyle.lineWidth = 2.0f;
	
	axisSet.xAxis.majorIntervalLength = [[NSDecimalNumber decimalNumberWithString:@"5"] decimalValue];
	axisSet.xAxis.minorTicksPerInterval = 4;
	axisSet.xAxis.majorTickLineStyle = lineStyle;
	axisSet.xAxis.minorTickLineStyle = lineStyle;
	axisSet.xAxis.axisLineStyle = lineStyle;
	axisSet.xAxis.minorTickLength = 5.0f;
	axisSet.xAxis.majorTickLength = 7.0f;
	//axisSet.xAxis.axisLabelOffset = 3.0f;
	
	axisSet.yAxis.majorIntervalLength = [[NSDecimalNumber decimalNumberWithString:@"5"] decimalValue];
	axisSet.yAxis.minorTicksPerInterval = 4;
	axisSet.yAxis.majorTickLineStyle = lineStyle;
	axisSet.yAxis.minorTickLineStyle = lineStyle;
	axisSet.yAxis.axisLineStyle = lineStyle;
	axisSet.yAxis.minorTickLength = 5.0f;
	axisSet.yAxis.majorTickLength = 7.0f;
	//axisSet.yAxis.axisLabelOffset = 3.0f;
	
	CPScatterPlot *xSquaredPlot = [[[CPScatterPlot alloc] 
									initWithFrame:graph.frame] autorelease];
	xSquaredPlot.identifier = @"X Squared Plot";
	xSquaredPlot.dataLineStyle.lineWidth = 1.0f;
	xSquaredPlot.dataLineStyle.lineColor = [CPColor greenColor];
	xSquaredPlot.dataSource = self;
	[graph addPlot:xSquaredPlot];
	
	
	/*
	CPPlotSymbol *greenCirclePlotSymbol = [CPPlotSymbol ellipsePlotSymbol];
	greenCirclePlotSymbol.fill = [CPFill fillWithColor:[CPColor greenColor]];
	greenCirclePlotSymbol.size = CGSizeMake(2.0, 2.0);
	//xSquaredPlot.defaultPlotSymbol = greenCirclePlotSymbol;  
	
	CPScatterPlot *xInversePlot = [[[CPScatterPlot alloc] 
									initWithFrame:graph.defaultPlotSpace] autorelease];
	xInversePlot.identifier = @"X Inverse Plot";
	xInversePlot.dataLineStyle.lineWidth = 1.0f;
	xInversePlot.dataLineStyle.lineColor = [CPColor blueColor];
	xInversePlot.dataSource = self;
	[graph addPlot:xInversePlot];*/
}

-(NSUInteger)numberOfRecordsForPlot:(CPPlot *)plot
{
	return 50;
}


-(NSNumber *)numberForPlot:(CPPlot *)plot field:(NSUInteger)fieldEnum  
			   recordIndex:(NSUInteger)index
{
	double xval=24 * index / 50;
	double yval = 12 + (30-12) * (rand() % 1000) / 1000.0f;
	if(fieldEnum == CPScatterPlotFieldX)
	{ return [NSNumber numberWithDouble:xval]; }
	else
	{ 
		if(plot.identifier == @"X Squared Plot")
		{ return [NSNumber numberWithDouble:yval]; }
		else
		{ return [NSNumber numberWithDouble:1/yval]; }
	}
}


/*
// Override to allow orientations other than the default portrait orientation.
- (BOOL)shouldAutorotateToInterfaceOrientation:(UIInterfaceOrientation)interfaceOrientation {
    // Return YES for supported orientations
    return (interfaceOrientation == UIInterfaceOrientationPortrait);
}
*/

- (void)didReceiveMemoryWarning {
    // Releases the view if it doesn't have a superview.
    [super didReceiveMemoryWarning];
    
    // Release any cached data, images, etc that aren't in use.
}

- (void)viewDidUnload {
    [super viewDidUnload];
    // Release any retained subviews of the main view.
    // e.g. self.myOutlet = nil;
}


- (void)dealloc {
    [super dealloc];
}


@end
