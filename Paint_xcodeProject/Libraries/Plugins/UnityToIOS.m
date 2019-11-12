//
//  UnityToIOS.m
//  Unity-iPhone
//
//  Created by zhongming on 2019/5/24.
//

#import "UnityToIOS.h"
#import "MBProgressHUD+PX.h"
#import <Photos/PHPhotoLibrary.h>
#import "ZPSwiftToObjcManager.h"
#import "ZhihuiJoin-Swift.h"
#import <Photos/Photos.h>
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
        result = @"fail";
        [MBProgressHUD showSuccess:@"保存失败！"];
    }
    else
    {
        result = @"success!";
        [MBProgressHUD showSuccess:@"保存成功！"];
    }
    NSLog(@"result---->%@", result);
    UnitySendMessage("GameMain", "PlatformToUnity_SavePhotoCallBack", result.UTF8String);
}

//保存到系统相册
-(void)SavePhotoToAlbum:(char *)path{
    NSLog(@"UnityToIOS_SavePhotoToAlbum Begin~~~~~~~~~~~~~");
    NSString *strRead = [NSString stringWithUTF8String:path];
    UIImage *img = [UIImage imageWithContentsOfFile:strRead];
    if(img){
        UIImageWriteToSavedPhotosAlbum(img, [UnityToIOS shareInstance] , @selector(image:didFinishSavingWithError:contextInfo:), NULL);
    }
}

//  获得相簿
-(PHAssetCollection *)createAssetCollection{
    
    //判断是否已存在
    PHFetchResult<PHAssetCollection *> *assetCollections = [PHAssetCollection fetchAssetCollectionsWithType:PHAssetCollectionTypeAlbum subtype:PHAssetCollectionSubtypeAlbumRegular options:nil];
    for (PHAssetCollection * assetCollection in assetCollections) {
        if ([assetCollection.localizedTitle isEqualToString:@"智绘拼接"]) {
            //说明已经有哪对象了
            return assetCollection;
        }
    }
    
    //创建新的相簿
    __block NSString *assetCollectionLocalIdentifier = nil;
    NSError *error = nil;
    //同步方法
    [[PHPhotoLibrary sharedPhotoLibrary]performChangesAndWait:^{
        // 创建相簿的请求
        assetCollectionLocalIdentifier = [PHAssetCollectionChangeRequest creationRequestForAssetCollectionWithTitle:@"智绘拼接"].placeholderForCreatedAssetCollection.localIdentifier;
    } error:&error];
    
    if (error)return nil;
    
    return [PHAssetCollection fetchAssetCollectionsWithLocalIdentifiers:@[assetCollectionLocalIdentifier] options:nil].lastObject;
}

//保存图片
-(void)saveImage:(char *)path{
    
    __block  NSString *assetLocalIdentifier;
    [[PHPhotoLibrary sharedPhotoLibrary]performChanges:^{
        
        //1.保存图片到相机胶卷中----创建图片的请求
        NSString *strRead = [NSString stringWithUTF8String:path];
        UIImage *img = [UIImage imageWithContentsOfFile:strRead];
        assetLocalIdentifier = [PHAssetCreationRequest creationRequestForAssetFromImage:img].placeholderForCreatedAsset.localIdentifier;
    } completionHandler:^(BOOL success, NSError * _Nullable error) {
        if(success == NO){
            NSLog(@"保存图片失败----(创建图片的请求)");
            dispatch_async(dispatch_get_main_queue(), ^{
                [MBProgressHUD showSuccess:@"保存失败！"];
            });
            return ;
        }
        // 2.获得相簿
        PHAssetCollection *createdAssetCollection = [self createAssetCollection];
        if (createdAssetCollection == nil) {
            dispatch_async(dispatch_get_main_queue(), ^{
                [MBProgressHUD showSuccess:@"保存图片成功----(创建相簿失败!)"];
            });
            return;
        }
        
        // 3.将刚刚添加到"相机胶卷"中的图片到"自己创建相簿"中
        [[PHPhotoLibrary sharedPhotoLibrary]performChanges:^{
            
            //获得图片
            PHAsset *asset = [PHAsset fetchAssetsWithLocalIdentifiers:@[assetLocalIdentifier] options:nil].lastObject;
            //添加图片到相簿中的请求
            PHAssetCollectionChangeRequest *request = [PHAssetCollectionChangeRequest changeRequestForAssetCollection:createdAssetCollection];
            // 添加图片到相簿
            [request addAssets:@[asset]];
        } completionHandler:^(BOOL success, NSError * _Nullable error) {
            if(success){
                NSLog(@"保存图片到创建的相簿成功");
                dispatch_async(dispatch_get_main_queue(), ^{
                    [MBProgressHUD showSuccess:@"保存成功！"];
                });
            }else{
                NSLog(@"保存图片到创建的相簿失败");
                dispatch_async(dispatch_get_main_queue(), ^{
                    [MBProgressHUD showSuccess:@"保存失败！"];
                });
            }
            UnitySendMessage("GameMain", "PlatformToUnity_SavePhotoCallBack", "result");
        }];
    }];
}

//休息页面打开
-(void)showResetViewCallBack{
    NSLog(@"休息页面开启~~~~~~");
    UnitySendMessage("GameMain", "PlatformToUnity_ShowRestView","NULL");//调用CallManager里的PlatformToUnity_ShowRestView方法
}

//休息页面关闭
-(void)hideResetViewCallBack{
    NSLog(@"休息页面关闭~~~~~~");
    UnitySendMessage("GameMain", "PlatformToUnity_HideRestView","NULL");
}

#if defined(__cplusplus)
extern "C" {
#endif
    
    void UnityToIOS_ResumeTime() {
         NSLog(@"开始计时～～～～～～～");
        [[ZPRestTimeManager shareInstance] resume];
    }
    void UnityToIOS_PauseTime() {
         NSLog(@"暂停计时～～～～～～～");
        [[ZPRestTimeManager shareInstance] pause];
    }
    
    void UnityToIOS_GoToPersonalCenter(){
        [[ZPSwiftToObjcManager shareInstance]pushVerificationView];
    }
    //保存图片到相册
    void UnityToIOS_SavePhotoToAlbum(char *path)
    {
        NSLog(@"UnityToIOS_SavePhotoToAlbum～～～～～～～");
        __block char *localPath = (char *)malloc(strlen(path));
        strcpy(localPath, path);
        [PHPhotoLibrary requestAuthorization:^(PHAuthorizationStatus status) {
            if(status == PHAuthorizationStatusNotDetermined){
                NSLog(@"尚未授权～～～～～～～");
//                [[UnityToIOS shareInstance]SavePhotoToAlbum:localPath];
                [[UnityToIOS shareInstance]saveImage:localPath];
            }else if(status == PHAuthorizationStatusRestricted){
                NSLog(@"受限制，无权限～～～～～～");
                UnitySendMessage("GameMain", "PlatformToUnity_SavePhotoCallBack", "");
                dispatch_async(dispatch_get_main_queue(), ^{
                    [MBProgressHUD showSuccess:@"您已禁止访问相册，请到系统设置中打开"];
                });
                return;
            }else if(status == PHAuthorizationStatusDenied){
                NSLog(@"用户拒绝授权～～～～～～～");
                UnitySendMessage("GameMain", "PlatformToUnity_SavePhotoCallBack", "");
                dispatch_async(dispatch_get_main_queue(), ^{
                    [MBProgressHUD showSuccess:@"您已禁止访问相册，请到系统设置中打开"];
                });
                return;
            }else{
                NSLog(@"·   用户已授权～～～～～～");
//                [[UnityToIOS shareInstance]SavePhotoToAlbum:localPath];
                [[UnityToIOS shareInstance]saveImage:localPath];
            }
        }];
    }
    
#if defined(__cplusplus)
}
#endif
@end
