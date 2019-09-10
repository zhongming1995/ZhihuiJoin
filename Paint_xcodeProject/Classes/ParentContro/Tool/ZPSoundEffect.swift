//
//  ZPSoundEffect.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/29.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit
import AudioToolbox

class ZPSoundEffect: NSObject {
    
    var soundID: SystemSoundID?
    var isCompletion: Bool = true
    // MARK: - Play
    @objc func playButtonSound() {
        guard let soundID = soundID else { return }
        AudioServicesPlaySystemSound(soundID)
    }
    @objc func play() {
        guard let soundID = soundID else { return }
        if isCompletion == true { //防鬼畜
            isCompletion = false
            AudioServicesPlaySystemSoundWithCompletion(soundID) {
                self.isCompletion = true
            }
        }
    }
    
    /// 播放提示音时使用 
    @objc func playAlertMusic() {
        guard let soundID = soundID else { return }
        if ZPMusicManager.shareInstance.isCompletion == true { //防鬼畜
            ZPMusicManager.shareInstance.isCompletion = false
            AudioServicesPlayAlertSoundWithCompletion(soundID) {
                ZPMusicManager.shareInstance.isCompletion = true
            }
        }
    }
    
    // MARK: - Public
    init(contentsOfFile path: String) {
        super.init()
        config(path: path)
    }
    
    private func config(path: String) {
        let aFileURL = URL.init(fileURLWithPath: path, isDirectory: false)
        var aSoundID: SystemSoundID = 0
        AudioServicesCreateSystemSoundID(aFileURL as CFURL, &aSoundID)
        soundID = aSoundID
    }
    
    deinit {
        guard let soundID = soundID else { return }
        AudioServicesDisposeSystemSoundID(soundID)
    }
    
}
