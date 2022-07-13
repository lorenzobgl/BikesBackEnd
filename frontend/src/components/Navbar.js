import React from 'react'
import logo from './assets/img/logo.png'
import './assets/css/nav.css'

export default function Navbar() {
    return (

        <nav className="navbar navbar-expand-lg">
            <div className="container">
                <img src={logo} />
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarTogglerDemo02" aria-controls="navbarTogglerDemo02" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                </button>
                <div className="collapse navbar-collapse" id="navbarTogglerDemo02">
                    <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                        <li className="nav-item">
                            <a className="nav-link" aria-current="page" href="#">Bikes</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="#">Assistance</a>
                        </li>
                    </ul>
                    <ul className="navbar-nav mb-2 mb-lg-0">
                        <li className="nav-item">
                            <a className="nav-link" href="#">Login</a>
                        </li>
                        <li className="nav-item">
                            <a className="nav-link" href="#">Register</a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
    )
}
