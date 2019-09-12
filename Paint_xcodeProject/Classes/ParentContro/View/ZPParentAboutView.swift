//
//  ZPParentAboutView.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/30.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class ZPParentAboutView: UIView {
    
    // MARK: - Lazy
    
    @IBOutlet weak var textLabel: UILabel!
    @IBOutlet weak var versionsLabel: UILabel!
    // MARK: - Init
    
    override func awakeFromNib() {
        let infoDictionary = Bundle.main.infoDictionary
        if let infoDictionary = infoDictionary {
            let appVersion = infoDictionary["CFBundleShortVersionString"] as! String
            versionsLabel.text = "版本号: V" + appVersion
        }
    }
}
