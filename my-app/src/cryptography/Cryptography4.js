import React,{Component} from 'react';
import {Button} from "react-bootstrap";

export class Cryptography4 extends Component{
    constructor(props){
        super(props);

        this.state={
            A: '',
            g: '',
            a: '',
            p: '',

            B: '',
            b: '',
            K_client: '',
            K_server: '',

            cryptoMessage: '',
            decryptedMessage: '',
            Message: ''
        };

        this.handleSubmit1 = this.handleSubmit1.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
    }

    async handleSubmit1(event){

        await fetch(process.env.REACT_APP_API +'Cryptography3/GetA', {
            headers : {
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({ A: result.mainA });
                    this.setState({ g: result.g });
                    this.setState({ p: result.p });
                    this.setState({ a: result.a });
                    console.log(result)
                },
                (error)=>{
                    alert('Failed');
                    return;
                })

        await fetch(process.env.REACT_APP_API+'Cryptography3/GetB',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                a: this.state.A,
                g: this.state.g,
                p: this.state.p
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({ B: result.mainB });
                    this.setState({ b: result.b });
                    console.log(result)
                },
                (error)=>{
                    alert('Failed');
                    return;
                })

        await fetch(process.env.REACT_APP_API+'Cryptography3/GetK',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                a: this.state.A,
                g: this.state.b,
                p: this.state.p
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({ K_client: result.k });
                    console.log(result)
                },
                (error)=>{
                    alert('Failed');
                    return;
                })

        await fetch(process.env.REACT_APP_API+'Cryptography4/EncryptionRC4',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                K: this.state.K_client,
                Message: this.state.Message
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({
                        cryptoMessage: result.cryptoMessage,
                        decryptedMessage: result.decryptedMessage
                    });
                    console.log(result)
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

    handleInputChange1 = e => this.setState({ Message: e.target.value });

    render(){

        return(
            <div className="container">
                <h1>Криптография 4. RC4</h1>
                <h5>K: {this.state.K_client}</h5>
                <h5>Зашифрованное сообщение: {this.state.cryptoMessage}</h5>
                <h5>Расшифрованное сообщение: {this.state.decryptedMessage}</h5>
                <p>
                    <label>
                        <h5>Сообщение:</h5>
                        <p><input
                            type="text"
                            value={this.state.Message}
                            onChange={this.handleInputChange1}/></p>
                    </label>
                </p>
                <p>
                    <Button className="mr-2" variant="info"
                            onClick={()=>this.handleSubmit1()}>
                        Отправить
                    </Button>
                </p>
            </div>
        )
    }
}