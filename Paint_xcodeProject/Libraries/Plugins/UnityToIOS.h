
//
//  UnityToIOS.h
//  Unity-iPhone
//
//  Created by zhongming on 2019/5/24.
//

#import <Foundation/Foundation.h>

@interface UnityToIOS : NSObject
+ (instancetype)shareInstance;


/**
 rest action call back
 */
-(void)showResetViewCallBack;

/**
 end rest action call back
 */
-(void)hideResetViewCallBack;
@end
