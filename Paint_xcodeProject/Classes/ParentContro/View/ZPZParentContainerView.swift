//
//  ZPZParentContainerView.swift
//  SmartPaint(Swift)
//
//  Created by Make on 2019/8/30.
//  Copyright © 2019 Make. All rights reserved.
//

import UIKit

class ZPZParentContainerView: UIView {

    // MARK: - Get & Set
    lazy var bgImageView: UIImageView = {
        let imageView = UIImageView.init()
        imageView.image = UIImage.init(named: "center_image_contentbg")
        return imageView
    }()
    lazy var restView: ZPParentRestView = {
        let view = ZPParentRestView.init()
        return view
    }()
    lazy var aboutView: ZPParentAboutView = {
        let view = Bundle.main.loadNibNamed("ZPParentAboutView", owner: self, options: nil)!.first as! ZPParentAboutView
        return view
    }()
    lazy var contactView: ZPParentContactView = {
        let view = Bundle.main.loadNibNamed("ZPParentContactView", owner: self, options: nil)!.first as! ZPParentContactView
        return view
    }()
    // MARK: - Public
    func adRestView() {
        aboutView.removeFromSuperview()
        contactView.removeFromSuperview()
        addSubview(restView)
        restView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
    }
    func addAboutView() {
        restView.removeFromSuperview()
        contactView.removeFromSuperview()
        addSubview(aboutView)
        aboutView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
    }
    func addContactView() {
        aboutView.removeFromSuperview()
        restView.removeFromSuperview()
        addSubview(contactView)
        contactView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
    }
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
        addSubview(bgImageView)
        bgImageView.snp.makeConstraints {
            $0.edges.equalToSuperview()
        }
    }
}
