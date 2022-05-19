import React,{Component} from 'react';
import {Button} from "react-bootstrap";

import Moment from 'moment';

export class Cryptography2 extends Component{
    constructor(props){
        super(props);

        this.state={
            login: '',
            password: '',

            hash_password: '',
            hash_time: '',
            hash_user: '',
            hash_server: '',

            is_registered: false
        };

        this.handleSubmit1 = this.handleSubmit1.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
        this.handleInputChange3 = this.handleInputChange3.bind(this);
        this.handleInputChange4 = this.handleInputChange4.bind(this);
    }

    async handleSubmit1(event){
        if (this.state.login.length === 0 || this.state.password.length === 0)
        {
            alert('Поля не заполнены');
            return;
        }

        this.setState({ is_registered: true });

        Moment.locale('en');
        await fetch(process.env.REACT_APP_API+'Cryptography2/PostFirst',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                login: this.state.login,
                password: this.state.hash_user
            })
        })
        .then(res=>res.json())
        .then((result)=>{
                if (result === 'Данный пользователь не зарегистрирован')
                {
                    alert('Данный пользователь не зарегистрирован');
                    this.setState({ is_registered: false });
                    return;
                }
                if (result === 'Вы уже авторизованы')
                {
                    return;
                }
                this.setState({ hash_time: result });
                this.setState({ is_registered: true });
            },
            (error)=>{
                alert('Failed');
                return;
            })

        if (this.state.is_registered === false)
        {
            this.setState({ is_registered: false });
            return;
        }

        await fetch(process.env.REACT_APP_API +'Cryptography2/GetHashText/' + this.state.password, {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
        .then(res=>res.json())
        .then((result)=>{
                this.setState({ hash_password: result });
            },
            (error)=>{
                alert('Failed');
                return;
            })

        await fetch(process.env.REACT_APP_API +'Cryptography2/GetHashText/' + this.state.hash_time + this.state.hash_password, {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({ hash_user: result });
                },
                (error)=>{
                    alert('Failed');
                    return;
                })

        await fetch(process.env.REACT_APP_API+'Cryptography2/PostSecond',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                login: this.state.login,
                password: this.state.hash_user
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                    alert(result)
                },
                (error)=>{
                    alert('Failed');
                    return;
                })
    }

    componentDidMount(){
    }

    componentDidUpdate(){
    }

    handleInputChange1 = e => this.setState({ login: e.target.value });

    handleInputChange2 = e => this.setState({ password: e.target.value });

    handleInputChange3 = e => this.setState({ login_to_send: e.target.value });

    handleInputChange4 = e => this.setState({ password_to_send: e.target.value });

    render(){

        return(
            <div className="container">
                <h1>Криптография 2. Аутентификация</h1>
                <p>
                    <label>
                        <h5>Логин:</h5>
                        <p><input
                            type="text"
                            value={this.state.login}
                            onChange={this.handleInputChange1}/></p>
                    </label>
                </p>
                <p>
                    <label>
                        <h5>Пароль:</h5>
                        <p><input
                            type="text"
                            value={this.state.password}
                            onChange={this.handleInputChange2}/></p>
                    </label>
                </p>
                <p>
                    <Button className="mr-2" variant="info"
                            onClick={()=>this.handleSubmit1()}>
                        Отправить
                    </Button>
                </p>
                <h5>Временная метка пользователя MD5: {this.state.hash_user}</h5>
            </div>
        )
    }
}