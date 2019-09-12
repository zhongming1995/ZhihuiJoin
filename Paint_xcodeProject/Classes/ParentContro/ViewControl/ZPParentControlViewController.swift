//
//  ZPParentControlViewController.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/30.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit
import Material
import StoreKit

class ZPParentControlViewController: UIViewController {
    
    // MARK: - Get & Set
    lazy var bgImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "center_image_bg")
        return imageView
    }()
    lazy var lionImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "center_image_xiaoshi")
        imageView.sizeToFit()
        return imageView
    }()
    lazy var evaluateButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setImage(UIImage.init(named: "center_appraise"), for: .normal)
        button.sizeToFit()
        button.addTarget(self, action: #selector(evaluateAction), for: .touchUpInside)
        return button
    }()
    lazy var leftButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setImage(UIImage.init(named: "center_back"), for: .normal)
        button.sizeToFit()
        button.addTarget(self, action: #selector(backAction), for: .touchUpInside)
        return button
    }()
    lazy var configButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setTitle("设置", for: .normal)
        button.setTitleColor(.white, for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: 27)
        button.setTitleColor(.init(red: 0.04, green: 0.81, blue: 0.29, alpha: 1.0), for: .selected)
        button.setImage(UIImage.init(named: "center_icon_setting_normal"), for: .normal)
        button.setImage(UIImage.init(named: "center_icon_setting_select"), for: .selected)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_normal"), for: .normal)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_select"), for: .selected)
        button.imageEdgeInsets = UIEdgeInsets.init(top: 0, left: 0, bottom: 0, right: CGFloat.ptWidth1024(w: 20))
        button.sizeToFit()
        button.addTarget(self, action: #selector(clickButtonAction(sender:)), for: .touchUpInside)
        return button
    }()
    lazy var aboutButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setTitle("关于", for: .normal)
        button.setTitleColor(.white, for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: 27)
        button.setTitleColor(.init(red: 0.04, green: 0.81, blue: 0.29, alpha: 1.0), for: .selected)
        button.setImage(UIImage.init(named: "center_icon_about_normal"), for: .normal)
        button.setImage(UIImage.init(named: "center_icon_about_select"), for: .selected)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_normal"), for: .normal)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_select"), for: .selected)
        button.imageEdgeInsets = UIEdgeInsets.init(top: 0, left: 0, bottom: 0, right: CGFloat.ptWidth1024(w: 20))
        button.sizeToFit()
        button.addTarget(self, action: #selector(clickButtonAction(sender:)), for: .touchUpInside)
        return button
    }()
    lazy var contactButton: UIButton = {
        let button = UIButton.init(type: .custom)
        button.setTitle("联系我们", for: .normal)
        button.setTitleColor(.white, for: .normal)
        button.titleLabel?.font = UIFont.systemFont(ofSize: 27)
        button.setTitleColor(.init(red: 0.04, green: 0.81, blue: 0.29, alpha: 1.0), for: .selected)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_normal"), for: .normal)
        button.setBackgroundImage(UIImage.init(named: "center_iconbg_select"), for: .selected)
        button.setImage(UIImage.init(named: "center_icon_contact_normal"), for: .normal)
        button.setImage(UIImage.init(named: "center_icon_contact_select"), for: .selected)
        button.imageEdgeInsets = UIEdgeInsets.init(top: 0, left: 0, bottom: 0, right: CGFloat.ptWidth1024(w: 20))
        button.sizeToFit()
        button.addTarget(self, action: #selector(clickButtonAction(sender:)), for: .touchUpInside)
        return button
    }()
    lazy var containerView: ZPZParentContainerView = {
        let view = ZPZParentContainerView.init()
        view.restView.progressView.delegate = self
        return view
    }()
    var buttons = [UIButton]()
    
    // MARK: - Touch
    @objc func clickButtonAction(sender: UIButton) {
        for button in buttons {
            button.isSelected = false
        }
        lionImageView.isHidden = true
        sender.isSelected = true
        if sender == configButton {
            containerView.adRestView()
        } else if sender == aboutButton {
            containerView.addAboutView()
        } else if sender == contactButton {
            lionImageView.isHidden = false
            containerView.addContactView()
        }
    }
    
    @objc func backAction() {
        dismiss(animated: true, completion: nil);
    }
    
    @objc func evaluateAction() {
        if #available(iOS 10.3, *) {
            SKStoreReviewController.requestReview()
        } else {
            // Fallback on earlier versions
        }
    }
    // MARK: - viewDidLoad
    override func viewDidLoad() {
        super.viewDidLoad()
        snpLayoutSubviews()
        clickButtonAction(sender: configButton)
    }
    
    // MARK: - Layout
    func snpLayoutSubviews() {
        view.addSubview(bgImageView)
        view.addSubview(evaluateButton)
        view.addSubview(leftButton)
        view.addSubview(configButton)
        view.addSubview(aboutButton)
        view.addSubview(contactButton)
        view.addSubview(containerView)
        view.addSubview(lionImageView)
        
        bgImageView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
        leftButton.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth1024(w: 16))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 14))
        }
        evaluateButton.snp.makeConstraints {
            $0.right.equalToSuperview().offset(-CGFloat.ptWidth1024(w: 16))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 14))
        }
        
        configButton.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth1024(w: 183))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 41))
            $0.width.equalTo(CGFloat.ptWidth1024(w: 211))
            $0.height.equalTo(CGFloat.ptHeight768(h: 74))
        }
        aboutButton.snp.makeConstraints {
            $0.left.equalTo(configButton.snp_rightMargin).offset(CGFloat.ptWidth1024(w: 13))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 41))
            $0.width.equalTo(CGFloat.ptWidth1024(w: 211))
            $0.height.equalTo(CGFloat.ptHeight768(h: 74))
        }
        contactButton.snp.makeConstraints {
            $0.left.equalTo(aboutButton.snp_rightMargin).offset(CGFloat.ptWidth1024(w: 13))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 41))
            $0.width.equalTo(CGFloat.ptWidth1024(w: 211))
            $0.height.equalTo(CGFloat.ptHeight768(h: 74))
        }
        containerView.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth1024(w: 20))
            $0.top.equalTo(configButton.snp_bottomMargin)
            $0.width.equalTo(CGFloat.ptWidth1024(w: 984))
            $0.height.equalTo(CGFloat.ptHeight768(h: 625))
        }
        lionImageView.snp.makeConstraints {
            $0.right.equalToSuperview().offset(-CGFloat.ptWidth1024(w: 17))
            $0.bottom.equalToSuperview()
        }
        buttons = [configButton, aboutButton, contactButton]
    }
}

extension ZPParentControlViewController: MKProgressDelegate {
    //改变休息时间
    func didChangeValue(index: Int) {
        var second = 0
        switch index {
        case 0:
            second = 15*60
        case 1:
            second = 30*60
        case 2:
            second = 45*60
        default:
            second = 60*60
        }
        UserDefaults.standard.setValue(second, forKey: ZPConstantString.userDefaultRestTime)
    }
}

struct ZPConstantString {
    static let userDefaultRestTime = "userDefaultRestTime"
}
