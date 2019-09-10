//
//  MathTool.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/6/11.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class MathTool: NSObject {
    
}

extension CGFloat {
    static func screenWidth() -> CGFloat {
        return UIScreen.main.bounds.size.width
    }
    static func screenHeight() -> CGFloat {
        return UIScreen.main.bounds.size.height
    }
    
    static func ptHeight768(h: CGFloat) -> CGFloat {
        return h/768.0*CGFloat.screenHeight()
    }
    
    static func ptWidth1024(w: CGFloat) -> CGFloat {
        return w / 1024.0 * CGFloat.screenWidth()
    }
    
    static func ptHeight(h: CGFloat) -> CGFloat {
        return h/512.0*CGFloat.screenHeight()
    }
    
    static func ptWidth(w: CGFloat) -> CGFloat {
        return w / 683.0 * CGFloat.screenWidth()
    }    
}

extension UIColor {
    
//    convenience init(red: Int, green: Int, blue: Int) {
//        assert(red >= 0 && red <= 255, "Invalid red component")
//        assert(green >= 0 && green <= 255, "Invalid green component")
//        assert(blue >= 0 && blue <= 255, "Invalid blue component")
//        
//        self.init(red: CGFloat(red) / 255.0, green: CGFloat(green) / 255.0, blue: CGFloat(blue) / 255.0, alpha: 1.0)
//    }
//    
//    convenience init(rgb: Int) {
//        self.init( red: (rgb >> 16) & 0xFF, green: (rgb >> 8) & 0xFF, blue: rgb & 0xFF)
//    }
//    
    /// 获取颜色的UInt32表示形式
    open var rgbaValue: UInt32 {
        var red: CGFloat = 0
        var green: CGFloat = 0
        var blue: CGFloat = 0
        var alpha: CGFloat = 0
        getRed(&red, green: &green, blue: &blue, alpha: &alpha)
        return UInt32(red * 255) << 0 | UInt32(green * 255) << 8 | UInt32(blue * 255) << 16 | UInt32(alpha * 255) << 24
    }
    
}

extension UIView {
    func getSnapShot() -> UIImage {
        UIGraphicsBeginImageContextWithOptions(bounds.size, false, contentScaleFactor)
        drawHierarchy(in: bounds, afterScreenUpdates: true)
        let image = UIGraphicsGetImageFromCurrentImageContext()
        UIGraphicsEndImageContext()
        return image!
    }
}

extension CGRect {
    static func scaleForRealFrame(x: CGFloat, y: CGFloat, width: CGFloat, height: CGFloat) -> CGRect {
        return CGRect.init(x: CGFloat.ptWidth1024(w: x),
                           y: CGFloat.ptHeight768(h: y),
                           width: CGFloat.ptWidth1024(w: width),
                           height: CGFloat.ptHeight768(h: height))
    }
}
