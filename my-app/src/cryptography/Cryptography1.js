import React,{Component} from 'react';
import {Button} from "react-bootstrap";

export class Cryptography1 extends Component{
    constructor(props){
        super(props);

        this.state={
            login: '',
            password: ''
        };

        this.handleSubmit1=this.handleSubmit1.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
    }

    handleSubmit1(event){
        if (this.state.login.length === 0 || this.state.password.length === 0)
        {
            alert('Поля не заполнены');
            return;
        }
        fetch(process.env.REACT_APP_API+'Cryptography1',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                login: this.state.login,
                password: this.state.password
            })
        })
        .then(res=>res.json())
        .then((result)=>{
                alert(result);
            },
            (error)=>{
                alert('Failed');
            })
    }

    componentDidMount(){
    }

    componentDidUpdate(){
    }

    handleInputChange1 = e => this.setState({ login: e.target.value });

    handleInputChange2 = e => this.setState({ password: e.target.value });

    render(){
        return(
            <div className="container">
                <h1>Криптография 1. Регистрация пользователя</h1>
                <p>
                    <label>
                        <p>Логин:</p>
                        <p><input
                            type="text"
                            value={this.state.login}
                            onChange={this.handleInputChange1}/></p>
                    </label>
                </p>
                <p>
                    <label>
                        <p>Пароль:</p>
                        <p><input
                            type="text"
                            value={this.state.password}
                            onChange={this.handleInputChange2}/></p>
                    </label>
                </p>
                <p>
                    <Button className="mr-2" variant="info"
                            onClick={()=>this.handleSubmit1()}>
                        Зарегистрироваться
                    </Button>
                </p>
            </div>
        )
    }
}