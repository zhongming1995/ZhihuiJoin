//
//  MKProgressBarView.swift
//  JinDutiao2
//
//  Created by Make on 2019/8/29.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class MKProgressBarView: UIView {
    
    var titleLabels = [UILabel]()
    var buttons = [UIButton]()
    var stepIndex = 0 {
        willSet {
            setStepIndex(stepIndex: newValue)
        }
    }
    weak var delegate: MKProgressDelegate?
    let buttonWidth = CGFloat(63.0)
    /// 指示器
    lazy var moveIndicator: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "center_icon_time_select")
        return imageView
    }()
    
    lazy var grayLineView: UIView = {
        let view = UIView.init()
        view.backgroundColor = UIColor(red: 1, green: 0.85, blue: 0.49, alpha: 1)
        view.layer.cornerRadius = 5
        return view
    }()
    lazy var progressLineView: UIView = {
        let view = UIView.init()
        view.backgroundColor = UIColor(red: 1, green: 0.73, blue: 0, alpha: 1)
        view.layer.cornerRadius = 5
        return view
    }()
    
    // MARK: - Public method
    func setStepIndex(stepIndex: Int) {
        
        let perWidth = grayLineView.frame.width / CGFloat(titleLabels.count-1)
        
        moveIndicator.center = buttons[stepIndex].center
        progressLineView.frame = CGRect.init(x: grayLineView.frame.minX,
                                             y: grayLineView.frame.minY,
                                             width: perWidth*CGFloat(stepIndex),
                                             height: grayLineView.frame.size.height)
        
        DispatchQueue.main.asyncAfter(deadline: .now() + 0.1) {
            for i in self.buttons.enumerated() {
                let index = i.offset
                if index <= stepIndex {
                    self.buttons[index].isSelected = true
                    self.titleLabels[index].textColor = UIColor.init(red: 65/255.0, green: 59/255.0, blue: 58/255.0, alpha: 1.0)
                } else {
                    self.buttons[index].isSelected = false
                    self.titleLabels [index].textColor = UIColor.init(rgb: 0xb19882)
                }
            }
        }
    }
    
    func setStepIndex(stepIndex: Int, animation: Bool) {
        if stepIndex >= 0 && stepIndex < titleLabels.count {
            if animation {
                UIView.animate(withDuration: 0.3) {
                    self.stepIndex = stepIndex
                }
            } else {
                self.stepIndex = stepIndex
            }
        }
    }
    
    // MARK: - Touch
    @objc func touchButton(sender: UIButton) {
        let index = buttons.firstIndex(of: sender)!
        setStepIndex(stepIndex: index, animation: true)
        delegate?.didChangeValue(index: index)
    }
    
    // MARK: - Init
    init(frame: CGRect, titles: [String]) {
        super.init(frame: frame)
        config(titles: titles)
        DispatchQueue.main.asyncAfter(deadline: .now() + 0.2) {
           self.readLocalForProgress()
        }
    }
    
   private func readLocalForProgress() {
       let t = UserDefaults.standard.value(forKey: ZPConstantString.userDefaultRestTime) as? Int
        var index = 0
        if t == 60*60 {
            index = 3
        } else if t == 45*60 {
            index = 2
        } else if t == 30*60 {
            index = 1
        } else {
            index = 0
        }
        setStepIndex(stepIndex: index, animation: true)
    }
    
    required init?(coder aDecoder: NSCoder) {
        fatalError("init(coder:) has not been implemented")
    }
    
    func config(titles: [String]) {
        addSubview(grayLineView)
        addSubview(progressLineView)
        
        for title in titles {
            let label = UILabel.init()
            label.text = title
            label.textColor = UIColor.init(rgb: 0xb19882)
            label.font = UIFont.boldSystemFont(ofSize: CGFloat.ptHeight768(h: 18))

            label.textAlignment = .center
            label.sizeToFit()
            addSubview(label)
            titleLabels.append(label)
            
            let button = UIButton.init(type: .custom)
            button.setImage(UIImage.init(named: "center_icon_time_normal"), for: .normal)
            button.setImage(UIImage.init(named: "center_icon_time_select"), for: .selected)
            addSubview(button)
            buttons.append(button)
            button.addTarget(self, action: #selector(touchButton(sender:)), for: .touchUpInside)
            
            let index = titles.firstIndex(of: title)!
            let w = buttonWidth
            let space = (frame.size.width - buttonWidth) / CGFloat(titles.count-1)
            let x = CGFloat(index) * space
            let y = CGFloat(0)
            button.frame = CGRect.init(x: x, y: y, width: w, height: w)
            label.center = CGPoint.init(x: button.center.x, y: button.frame.maxY+20)
        }
        addSubview(moveIndicator)
        moveIndicator.frame = buttons.first!.frame
        
        grayLineView.frame = CGRect.init(x: buttonWidth/2,
                                         y: buttons.first!.center.y - 27/2,
                                         width: frame.width-buttonWidth,
                                         height: 27)
        
        progressLineView.frame = CGRect.init(x: grayLineView.frame.minX, y: grayLineView.frame.minY, width: 10, height: 27)
    }
}

protocol MKProgressDelegate: AnyObject {
    func didChangeValue(index: Int)
}
