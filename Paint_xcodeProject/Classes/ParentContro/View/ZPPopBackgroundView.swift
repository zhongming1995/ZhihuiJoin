//
//  ZPPopBackgroundView.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/9/3.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class ZPPopBackgroundView: UIView {
    
    init() {
        super.init(frame: .init(x: 0, y: 0, width: .screenWidth(), height: .screenHeight()))
    }
    
   @objc lazy var popView: ZPVerificationView = {
        let view = ZPVerificationView.init(frame: .scaleForRealFrame(x: 226, y: 119, width: 572, height: 530))
        view.cancelButton.addTarget(self, action: #selector(cancelAction), for: .touchUpInside)
        return view
    }()
    
    @objc func cancelAction() {
        dismiss()
    }
    
    override func touchesBegan(_ touches: Set<UITouch>, with event: UIEvent?) {
        if touches.count == 1, let touch = touches.first {
            let point = touch.location(in: self)
            if !popView.frame.contains(point) {
                dismiss()
            }
        }
    }
    
   @objc func addToSuperView(superView: UIView) {
        superView.addSubview(self)
        addSubview(popView)
        popView.configNumber()
        animate([.background(color: .init(white: 0.2, alpha: 0.5)),
                      .fadeIn])
        popView.animate([.fadeIn])
    }
    
   @objc func dismiss() {
        animate([.background(color: .clear),
                 .fadeOut])
        popView.animate([.fadeOut])
        DispatchQueue.main.asyncAfter(deadline: .now() + 0.3) {
            self.removeFromSuperview()
        }
    }
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
}
