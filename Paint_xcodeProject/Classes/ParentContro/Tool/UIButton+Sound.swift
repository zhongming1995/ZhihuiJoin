//
//  UIButton+Sound.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/29.
//  Copyright © 2019 Make. All rights reserved.
//

import Foundation
import UIKit
extension UIButton {
    open override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        super.touchesBegan(touches, with: event)
        ZPMusicManager.shareInstance.buttonSound.playButtonSound()
    }
}

extension UICollectionViewDelegate {

}
