import React,{Component} from 'react';
import { NavLink } from 'react-router-dom';
import { Navbar,Nav } from 'react-bootstrap';

export class Navigation extends Component {

    render() {
        return(
            <Navbar bg="light" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav"/>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/Caesar">
                            Цезарь
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/Vigener">
                            Виженер
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/Gamming">
                            Гаммирование
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/Task4">
                            4 задание
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/Task5">
                            5 задание
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/InformationSecurity/RSA">
                            RSA
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/cryptography/Cryptography1">
                            Криптография 1
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/cryptography/Cryptography2">
                            Криптография 2
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/cryptography/Cryptography3">
                            Криптография 3
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/cryptography/Cryptography4">
                            Криптография 4
                        </NavLink>
                        <NavLink className="d-inline p-2 bg-light text-black" to="/cryptography/Cryptography5">
                            Криптография 5
                        </NavLink>
                    </Nav>
                </Navbar.Collapse>
            </Navbar>
        )
    }
}