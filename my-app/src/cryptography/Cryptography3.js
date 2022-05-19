import React,{Component} from 'react';
import {Button} from "react-bootstrap";

export class Cryptography3 extends Component{
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
            K_server: ''
        };

        this.handleSubmit1 = this.handleSubmit1.bind(this);
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

        await fetch(process.env.REACT_APP_API+'Cryptography3/GetK',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                a: this.state.B,
                g: this.state.a,
                p: this.state.p
            })
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({ K_server: result.k });
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

    render(){

        return(
            <div className="container">
                <h1>Криптография 3. Алгоритм Диффи-Хеллмана</h1>
                <h5>A: {this.state.A}</h5>
                <h5>g: {this.state.g}</h5>
                <h5>p: {this.state.p}</h5>
                <h5>a: {this.state.a}</h5>
                <h5>B: {this.state.B}</h5>
                <h5>b: {this.state.b}</h5>
                <h5>K на клиенте: {this.state.K_client}</h5>
                <h5>К на сервере: {this.state.K_server}</h5>
                <p>
                    <Button className="mr-2" variant="info"
                            onClick={()=>this.handleSubmit1()}>
                        Сгенерировать параметры
                    </Button>
                </p>
            </div>
        )
    }
}