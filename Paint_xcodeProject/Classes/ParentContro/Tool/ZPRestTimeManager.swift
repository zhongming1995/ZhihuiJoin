//
//  ZPRestTimeManager.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/30.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

enum ZPRestStatus {
    case normal
    case rest
}

protocol ZPRestCountDownProtocol: AnyObject {
    func countDown(surplus: Int)
}

class ZPRestTimeManager: NSObject {
    
   @objc static let shareInstance = ZPRestTimeManager()
    var checkTime = 1
    
    lazy var timer: Timer = {
        let timer = Timer.init(timeInterval: TimeInterval(self.checkTime), target: self, selector: #selector(checkTimer), userInfo: nil, repeats: true)
        RunLoop.main.add(timer, forMode: .default)
        return timer
    }()
    
    lazy var countDownTimer: Timer = {
        let timer = Timer.init(timeInterval: 1, target: self, selector: #selector(countDownAction), userInfo: nil, repeats: true)
        RunLoop.main.add(timer, forMode: .default)
        return timer
    }()
    
    var restTime: Int {
        let t = UserDefaults.standard.value(forKey: ZPConstantString.userDefaultRestTime) as? Int
        return t ?? 15*60
    }
    private(set) var countDownTime = 60 * 3 //倒计时
    private(set) var currentRestTime: Int = 0 //当前使用计时
    private(set) var currentCountdownTime: Int = 0 //当前休息及时
    private(set) var currentStatus: ZPRestStatus = .normal
    
    weak var delegate: ZPRestCountDownProtocol?
    
    var currentTimeInterval: TimeInterval?
    
    // MARK: - Public
   @objc func changeRestTime(second: Int) {
        countDownTime = second
    }
   @objc func saveCurrentTime() {
        if currentStatus == .rest {
           currentTimeInterval = Date().timeIntervalSince1970
        }
    }
   @objc func comparisonTime(time: TimeInterval) {
        guard currentStatus == .rest else { return}
        guard let currentTimeInterval = currentTimeInterval else {
            return
        }
        let t = abs(time - currentTimeInterval)
    
        if Int(t)+currentCountdownTime >= countDownTime { //退出的时间大于休息时间
            endRestAction()
        } else {
            countDownTime -= Int(t)
        }
    }
    
    /// 清空计时
   @objc func cleanTime() {
        currentRestTime = 0
    }
    
    /// 暂停计时 在退出控制器时候调用
   @objc func pause() {
        guard timer.isValid else { return }
        timer.fireDate = Date.distantFuture
    }
    
    /// 继续计时 在进入控制器的时候调用
   @objc func resume() {
        guard timer.isValid else { return }
        currentStatus = .normal
        timer.fireDate = Date.init()
    }
    
    /// 暂停倒计时
   @objc func pauseCountDown() {
        guard countDownTimer.isValid else { return }
        countDownTimer.fireDate = Date.distantFuture
    }
    
    /// 开始一轮倒计时
   @objc func resumeCountDown() {
        guard countDownTimer.isValid else { return }
        resetCountDownTime()
        currentStatus = .rest
        countDownTimer.fireDate = Date.init()
    }

    // MARK: - 定时检查
    @objc func checkTimer() {
        guard currentStatus == .normal else { return }
        if currentRestTime >= restTime {
            restAction()
        } else {
            accumulationTimeAction()
        }
    }
    @objc func countDownAction() {
        guard currentStatus == .rest else {return }
        if countDownTime <= currentCountdownTime {
            endRestAction()
        } else {
            resumeRestAction()
        }
    }
    
    // MARK: - Private
    
    /// 累加时间
    private func accumulationTimeAction() {
        currentStatus = .normal
        currentRestTime += checkTime
        
    }
    /// 开始休息
    private func restAction() {
        currentStatus = .rest
        cleanTime()
        pause() //暂停
        resumeCountDown() // 开启休息倒计时
        presentToRestVC()
    }
    
    /// 结束休息
    public func endRestAction() {
        dismisRestVC()
        pauseCountDown()
        currentStatus = .normal
        resume() //开启下一轮计时
    }
    
    /// 累加休息时间
    private func resumeRestAction() {
        currentCountdownTime += 1
        currentStatus = .rest
        delegate?.countDown(surplus: countDownTime-currentCountdownTime)
    }
    func resetCountDownTime() {
        currentCountdownTime = 0
    }
    
    // MARK: - 跳转
    private func presentToRestVC() {
        let vc = ZPRestViewController.init()
        UIApplication.shared.keyWindow?.rootViewController?.present(vc, animated: true, completion: nil)
    }
    private func dismisRestVC() {        UIApplication.shared.keyWindow?.rootViewController?.presentedViewController?.dismiss(animated: true, completion: nil)
    }
    
}
