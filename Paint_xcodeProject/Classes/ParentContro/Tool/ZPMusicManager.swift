//
//  ZPMusicManager.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/7/24.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit
import AVFoundation

class ZPMusicManager: NSObject {
    
    static let shareInstance =  ZPMusicManager()
    var isCompletion: Bool = true
    
    lazy var buttonSound: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "common_button", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    
    lazy var snapshotSound: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "camera", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    
    lazy var restMusicArray: [ZPSoundEffect] = {
        let array = [self.restMusic1, self.restMusic2, self.restMusic3, self.restMusic4]
        return array
    }()
    
    lazy var restMusic1: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "rest_0", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    lazy var restMusic2: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "rest_1", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    lazy var restMusic3: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "rest_2", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    lazy var restMusic4: ZPSoundEffect = {
        let path = Bundle.main.path(forResource: "rest_3", ofType: "mp3")!
        let sound = ZPSoundEffect.init(contentsOfFile: path)
        return sound
    }()
    lazy var fillSounds: [ZPSoundEffect] = {
        var array = [ZPSoundEffect]()
        for index in 0...1 {
            let name = "fill_"+"\(index)"
            let path = Bundle.main.path(forResource: name, ofType: "mp3")!
            let sound = ZPSoundEffect.init(contentsOfFile: path)
            array.append(sound)
        }
        return array
    }()
    lazy var penSounds: [ZPSoundEffect] = {
        var array = [ZPSoundEffect]()
        for index in 0...5 {
            let name = "material_"+"\(index)"
            let path = Bundle.main.path(forResource: name, ofType: "mp3")!
            let sound = ZPSoundEffect.init(contentsOfFile: path)
            array.append(sound)
        }
        return array
    }()
    lazy var colorSounds: [ZPSoundEffect] = {
        var array = [ZPSoundEffect]()
        for index in 0...14 {
            let name = "color_"+"\(index)"
            let path = Bundle.main.path(forResource: name, ofType: "mp3")!
            let sound = ZPSoundEffect.init(contentsOfFile: path)
            array.append(sound)
        }
        return array
    }()

   lazy var magicPenSounds: [ZPSoundEffect] = {
        var array = [ZPSoundEffect]()
        for index in 0...9 {
            let name = "style_"+"\(index)"
            let path = Bundle.main.path(forResource: name, ofType: "mp3")!
            let sound = ZPSoundEffect.init(contentsOfFile: path)
            array.append(sound)
        }
        return array
    }()
    
    lazy var musicPlayer: AVAudioPlayer? = {
        let filePath = Bundle.main.path(forResource: "kanong", ofType: "mp3")!
        let url = URL.init(fileURLWithPath: filePath)
        do {
            let musicPlayer = try AVAudioPlayer.init(contentsOf: url)
            musicPlayer.numberOfLoops = -1
            musicPlayer.volume = 0.3
            return musicPlayer
        } catch {
            print(error)
            return nil
        }
    }()
    
    public func play() {
        musicPlayer?.play()
    }
    
    public func pause() {
        musicPlayer?.pause()
    }
}
