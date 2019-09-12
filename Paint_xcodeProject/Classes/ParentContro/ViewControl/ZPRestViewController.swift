//
//  ZPRestViewController.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/9/2.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class ZPRestViewController: UIViewController {
    
    // MARK: - Get & Set
    lazy var bgImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "xiuxitu")
        return imageView
    }()
    lazy var titleLabel: UILabel = {
        let label = UILabel.init()
        label.textColor = UIColor(red: 0, green: 0.58, blue: 0.04, alpha: 1)
        label.font = UIFont.systemFont(ofSize: CGFloat.ptHeight768(h: 30))
        label.text = "休息倒计时"
        return label
    }()
    lazy var timeLabel: MKCountDownLabel = {
        let label = MKCountDownLabel.init(with: 60)
        return label
    }()
    lazy var backButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setImage(UIImage.init(named: "back_icon"), for: .normal)
        button.addTarget(self, action: #selector(backAction), for: .touchDown)
        button.sizeToFit()
        return button
    }()
    override func viewDidLoad() {
        super.viewDidLoad()
        snpLayoutSubviews()
        ZPRestTimeManager.shareInstance.delegate = self
    }
    
    // MARK: - Touch Event
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        let index = Int(arc4random()%4)
        ZPMusicManager.shareInstance.restMusicArray[index].playAlertMusic()
    }
    
    @objc func backAction() {
        let view = ZPPopBackgroundView.init()
        view.addToSuperView(superView: self.view)
        weak var weakSelf = self
        weak var weakView = view
        view.popView.rightBlock = {
            if $0 == true {
                weakView?.dismiss()
                weakSelf?.dismiss(animated: true, completion: nil)
                ZPRestTimeManager.shareInstance.endRestAction()
            } else {
                weakView?.dismiss()
            }
        }
    }
    // MARK: - Layout
    func snpLayoutSubviews() {
        view.addSubview(bgImageView)
        view.addSubview(backButton)
        view.addSubview(timeLabel)
        view.addSubview(titleLabel)
        
        bgImageView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
        timeLabel.snp.makeConstraints {
            $0.centerX.equalToSuperview()
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 170))
        }
        titleLabel.snp.makeConstraints {
            $0.centerX.equalToSuperview()
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 136))
        }
        backButton.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth(w: 7))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight(h: 7))
        }
    }
    
}

extension ZPRestViewController: ZPRestCountDownProtocol {
    func countDown(surplus: Int) {
        timeLabel.startCountDownWithAnimation(second: surplus)
    }
}
