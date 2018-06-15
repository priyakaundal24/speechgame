//
//  StartAppObject.h
//  Unity
//
//  Created by StartApp on 6/8/14.
//  Copyright (c) 2013 StartApp. All rights reserved.
//  SDK version 3.5.1_Unity


#import <Foundation/Foundation.h>
#import "STAStartAppAd.h"
#import "STASplashPreferences.h"

@interface STAUnityAd : NSObject <STADelegateProtocol>

-(void)loadAd;
-(void)loadRewardedVideoAd;
-(void)showAd;
-(void)showAdWithAdTag:(const char *)adTag;

-(BOOL)shouldAutoRotate;
-(BOOL)isReady;

-(void)showSplashAdWithPref:(STASplashPreferences *)splashPreferences;


-(STASplashMode) getSplashModeFromChar:(const char *)splashMode;
-(STASplashMinTime) getSplashMinTimeFromChar:(const char *)splashMinTime;
-(STASplashAdDisplayTime) getSplashAdDisplayTimeFromChar:(const char *)splashAdDisplayTime;
-(STASplashTemplateTheme) getSplashTemplateThemeFromChar:(const char *)splashTemplateTheme;
-(STASplashLoadingIndicatorType) getSplashLoadingIndicatorTypeFromChar:(const char *)splashLoadingIndicatorType;



@end
