//
//  ZPSwiftToObjcManager.m
//  Unity-iPhone
//
//  Created by Make on 2019/9/10.
//

#import "ZPSwiftToObjcManager.h"
#import "ZhihuiJoin-Swift.h"
#import "UnityAppController.h"
@implementation ZPSwiftToObjcManager

+ (instancetype)shareInstance {
    static ZPSwiftToObjcManager *m = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        m = [[ZPSwiftToObjcManager alloc]init];
    });
    return m;
}

- (void)pushVerificationView{
    ZPPopBackgroundView *bgView = [[ZPPopBackgroundView alloc]init];
    [bgView addToSuperViewWithSuperView:[UIApplication sharedApplication].keyWindow];
    
    ZPPopBackgroundView __weak *weakView = bgView;
    bgView.popView.rightBlock = ^(BOOL b) {
        if (b) {
            [weakView dismiss];
            UnityAppController *appDelegate = GetAppController();
            ZPParentControlViewController *vc = [ZPParentControlViewController new];
            [appDelegate.rootViewController presentViewController:vc animated:YES completion:nil];
        } else {
            [weakView dismiss];
        }
    };
    
}
@end
