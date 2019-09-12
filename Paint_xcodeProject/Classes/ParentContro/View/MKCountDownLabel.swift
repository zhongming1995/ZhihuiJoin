//
//  MKCountDownLabel.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/9/2.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class MKCountDownLabel: UILabel {

    func configLabel() {
        textColor = UIColor(red: 0, green: 0.71, blue: 0.05, alpha: 1)
        font = UIFont.boldSystemFont(ofSize: CGFloat.ptHeight768(h: 63))
        textAlignment = .center
        sizeToFit()
    }
    
    init(with second: Int) {
        super.init(frame: .zero)
        configLabel()
    }
    
    func startCountDownWithAnimation(second: Int) {
        let time = timeToString(time: second)
        text = time
    }
    
    private func timeToString(time: Int) -> (String) {
        let hour = time / (60*60)
        let minute = time / 60
        let sec = time % 60
        let string = String.init(format: "%02d:%02d:%02d", hour, minute, sec)
        return string
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }

}
