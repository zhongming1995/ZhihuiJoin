//
//  ZPVerificationView.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/9/3.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class ZPVerificationView: UIView {
    // MARK: - Get & Set
    lazy var bgImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "popover_image_bg")
        return imageView
    }()
    lazy var cancelButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setBackgroundImage(UIImage.init(named: "popover_icon_close"), for: .normal)
        return button
    }()
    lazy var answerButton1: UIButton = {
        let button = UIButton.init(type: .custom)
        button.addTarget(self, action: #selector(answerAction(sender:)), for: .touchUpInside)
        button.setBackgroundImage(UIImage.init(named: "popover_icon_bg1"), for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: CGFloat.ptHeight768(h: 45))
        return button
    }()
    lazy var answerButton2: UIButton = {
        let button = UIButton.init(type: .custom)
        button.addTarget(self, action: #selector(answerAction(sender:)), for: .touchUpInside)
        button.setBackgroundImage(UIImage.init(named: "popover_icon_bg2"), for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: CGFloat.ptHeight768(h: 45))
        return button
    }()
    lazy var answerButton3: UIButton = {
        let button = UIButton.init(type: .custom)
        button.addTarget(self, action: #selector(answerAction(sender:)), for: .touchUpInside)
        button.setBackgroundImage(UIImage.init(named: "popover_icon_bg3"), for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: CGFloat.ptHeight768(h: 45))
        return button
    }()
    lazy var numberLabel: UILabel = {
        let label = UILabel.init()
        label.font = UIFont.boldSystemFont(ofSize: CGFloat.ptHeight(h: 30))
        label.textColor = UIColor(red: 0.04, green: 0.81, blue: 0.29, alpha: 1)
        label.textAlignment = .center
        label.layer.borderWidth = 5
        label.layer.borderColor = UIColor.init(rgb: 0xFFFFECBA).cgColor
        label.layer.masksToBounds = true
        label.layer.cornerRadius = CGFloat.ptHeight768(h: 80)/2
        label.backgroundColor = .white
        return label
    }()
    lazy var titleImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "popover_text_yanzheng")
        return imageView
    }()
    
    // MARK: - Touch Event
    @objc func backAction() {
        
    }
    var numberA: Int = 0
    var numberB: Int = 0
    
  @objc var rightBlock: ((_ isRight: Bool) -> Void)?
    
    @objc func answerAction(sender: UIButton) {
        let result = Int(sender.currentTitle!)
        if result == numberA+numberB { //正确
            rightBlock?(true)
        } else { //错误
            rightBlock?(false)
        }
    }
    
    // MARK: - Init
    override init(frame: CGRect) {
        super.init(frame: frame)
        configSubviews()
        configNumber()
    }
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    func configNumber() {
        numberA = Int(arc4random()%100)
        numberB = Int(arc4random()%100)
        
        numberLabel.text = "\(numberA)"+"+"+"\(numberB)"+"=?"
        
        var resultA = String(Int(arc4random()%50+1))
        var resultB = String(Int(arc4random()%100+1))
        var resultC = String(Int(arc4random()%200+1))
        
        let real = String(Int(numberA+numberB))
        
        if Int(real)! <= Int(resultA)! {
            resultA = real
        } else if Int(real)! <= Int(resultB)! {
            resultB = real
        } else {
            resultC = real
        }
        
        answerButton1.setTitle(resultA, for: .normal)
        answerButton2.setTitle(resultB, for: .normal)
        answerButton3.setTitle(resultC, for: .normal)
    }
    func configSubviews() {
        addSubview(bgImageView)
        addSubview(cancelButton)
        addSubview(answerButton1)
        addSubview(answerButton2)
        addSubview(answerButton3)
        addSubview(numberLabel)
        addSubview(titleImageView)
        
        bgImageView.frame = bounds
        
        cancelButton.frame = .scaleForRealFrame(x: 477, y: 111, width: 65, height: 65)
        
        titleImageView.frame = .scaleForRealFrame(x: 208, y: 189, width: 157, height: 38)
        titleImageView.sizeToFit()
        
        numberLabel.frame = .scaleForRealFrame(x: 134, y: 256, width: 305, height: 80)
        
        answerButton1.frame = .scaleForRealFrame(x: 109, y: 361, width: 96, height: 96)
        answerButton2.frame = .scaleForRealFrame(x: 238, y: 361, width: 96, height: 96)
        answerButton3.frame = .scaleForRealFrame(x: 367, y: 361, width: 96, height: 96)

    }
}
