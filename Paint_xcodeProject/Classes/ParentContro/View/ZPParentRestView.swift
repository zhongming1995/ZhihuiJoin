//
//  ZPParentRestView.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/30.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit
import SnapKit
class ZPParentRestView: UIView {

    // MARK: - Lazy
    lazy var progressView: MKProgressBarView = {
        let progressView = MKProgressBarView.init(frame: .init(x: CGFloat.ptWidth1024(w: 173),
                                                               y: CGFloat.ptHeight768(h: 250),
                                                               width: CGFloat.ptWidth1024(w: 655),
                                                               height: CGFloat.ptHeight768(h: 63)),
                                                  titles: ["15分钟", "30分钟", "45分钟", "1小时"])
        return progressView
    }()
    
    lazy var imageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "center_icon_time")
        return imageView
    }()
    lazy var textLabel: UILabel = {
        let label = UILabel()
        let attrString = NSMutableAttributedString(string: "每次使用时长")
        label.numberOfLines = 0
        let attr: [NSAttributedString.Key: Any] = [.font: UIFont.systemFont(ofSize: 29),
                                                    .foregroundColor: UIColor(red: 0.25, green: 0.23, blue: 0.23, alpha: 1)]
        attrString.addAttributes(attr, range: NSRange(location: 0, length: attrString.length))
        label.attributedText = attrString
        return label
    }()

    // MARK: - Init
    init() {
        super.init(frame: .zero)
        snpLayoutSubviews()
    }
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    // MARK: - Layout
    func snpLayoutSubviews() {
        addSubview(progressView)
        addSubview(imageView)
        addSubview(textLabel)
        
        imageView.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth1024(w: 171))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 165))
            $0.width.equalTo(CGFloat.ptWidth1024(w: 47))
            $0.height.equalTo(CGFloat.ptHeight768(h: 47))
        }
        textLabel.snp.makeConstraints {
            $0.left.equalToSuperview().offset(CGFloat.ptWidth1024(w: 231))
            $0.top.equalToSuperview().offset(CGFloat.ptHeight768(h: 175))
        }
    }
}
