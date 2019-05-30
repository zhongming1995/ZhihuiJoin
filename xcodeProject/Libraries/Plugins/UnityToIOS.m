//
//  UnityToIOS.m
//  Unity-iPhone
//
//  Created by zhongming on 2019/5/24.
//

#import "UnityToIOS.h"
#import "MBProgressHUD+PX.h"
#import <Photos/PHPhotoLibrary.h>

@implementation UnityToIOS

//单例类
+ (instancetype)shareInstance{
   static UnityToIOS *mIns = nil;
    static dispatch_once_t onceToken;
    dispatch_once(&onceToken, ^{
        mIns = [[UnityToIOS alloc]init];
    });
    return mIns;
}

//图片保存到本地的回调
-(void)image:(UIImage*)image didFinishSavingWithError:(NSError*)error contextInfo:(void*)contextInfo
{
    NSString* result;
    if(error)
    {
        result = @"图片保存到相册失败!";
        [MBProgressHUD showSuccess:@"保存失败！"];
    }
    else
    {
        result = @"图片保存到相册成功!";
        [MBProgressHUD showSuccess:@"保存成功！"];
    }
    NSLog(@"result---->%@", result);
}

-(void)SavePhotoToAlbum:(char *)path{
    NSLog(@"UnityToIOS_SavePhotoToAlbum Begin~~~~~~~~~~~~~");
    NSString *strRead = [NSString stringWithUTF8String:path];
    UIImage *img = [UIImage imageWithContentsOfFile:strRead];
    if(img){
        UIImageWriteToSavedPhotosAlbum(img, [UnityToIOS shareInstance] , @selector(image:didFinishSavingWithError:contextInfo:), NULL);
    }
}

#if defined(__cplusplus)
extern "C" {
#endif
    //保存图片到相册
    void UnityToIOS_SavePhotoToAlbum(char *path)
    {
        __block char *localPath = (char *)malloc(strlen(path));
        strcpy(localPath, path);
         [PHPhotoLibrary requestAuthorization:^(PHAuthorizationStatus status) {
             if(status == PHAuthorizationStatusNotDetermined){
                 NSLog(@"尚未授权～～～～～～～");
                 [[UnityToIOS shareInstance]SavePhotoToAlbum:localPath];
             }else if(status == PHAuthorizationStatusRestricted){
                 NSLog(@"受限制，无权限～～～～～～");
                 //             [MBProgressHUD showSuccess:@"无相册使用权限！"];
                 dispatch_async(dispatch_get_main_queue(), ^{
                     [MBProgressHUD showSuccess:@"您已禁止访问相册，请到系统设置中打开"];
                 });
                 return;
             }else if(status == PHAuthorizationStatusDenied){
                 NSLog(@"用户拒绝授权～～～～～～～");
                 //             [MBProgressHUD showSuccess:@"您已禁止访问相册，请到系统设置中打开"];
                 dispatch_async(dispatch_get_main_queue(), ^{
                     [MBProgressHUD showSuccess:@"您已禁止访问相册，请到系统设置中打开"];
                 });
                 return;
             }else{
                 NSLog(@"用户已授权～～～～～～");
                 [[UnityToIOS shareInstance]SavePhotoToAlbum:localPath];
             }
         }];
    }
    
#if defined(__cplusplus)
}
#endif
@end