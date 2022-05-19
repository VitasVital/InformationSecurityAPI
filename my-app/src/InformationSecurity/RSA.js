import React,{Component} from 'react';

export class RSA extends Component{
    constructor(props){
        super(props);

        this.state={
            input_text: '',
            cryptogram: '',
            bit_count: '',
            P: '',
            Q: '',
            e: '',
            d: '',
            fi_n: '',
            n: '',
            input_d: '',
            input_n: '',

            textRequest6_res1: [''],
            textRequest6_res2: ['']
        };

        this.handleSubmit1=this.handleSubmit1.bind(this);
        this.handleSubmit2=this.handleSubmit2.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
        this.handleInputChange3 = this.handleInputChange3.bind(this);
        this.handleInputChange4 = this.handleInputChange4.bind(this);
        this.handleInputChange5 = this.handleInputChange5.bind(this);
    }

    handleSubmit1(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec6',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result: 1,
                    input_text: this.state.input_text,
                    cryptogram: this.state.cryptogram,
                    bit_count: this.state.bit_count,
                    P: '',
                    Q: '',
                    e: '',
                    d: '',
                    fi_n: '',
                    n: '',
                    input_d: this.state.input_d,
                    input_n: this.state.n,
                    result_1: '',
                    result_2: ''
                }
            )
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({textRequest6_res1:result});
                },
                (error)=>{
                    alert('Failed');
                })
    }

    handleSubmit2(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec6',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result: 2,
                    input_text: this.state.input_text,
                    cryptogram: this.state.cryptogram,
                    bit_count: this.state.bit_count,
                    P: '',
                    Q: '',
                    e: '',
                    d: '',
                    fi_n: '',
                    n: '',
                    input_d: this.state.input_d,
                    input_n: this.state.input_n,
                    result_1: '',
                    result_2: ''
                }
            )
        })
            .then(res=>res.json())
            .then((result)=>{
                    this.setState({textRequest6_res2:result});
                },
                (error)=>{
                    alert('Failed');
                })
    }


    handleInputChange1(event) {
        this.setState({input_text: event.target.value});
    }

    handleInputChange2(event) {
        this.setState({cryptogram: event.target.value});
    }

    handleInputChange3(event) {
        this.setState({bit_count: event.target.value});
    }

    handleInputChange4(event) {
        this.setState({input_d: event.target.value});
    }

    handleInputChange5(event) {
        this.setState({input_n: event.target.value});
    }

    componentDidMount(){
    }

    componentDidUpdate(){
    }
    render(){
        return(
            <div className="container">
                <h1>RSA</h1>

                <p>Битность:</p>
                <p><input
                    type="text"
                    value={this.state.bit_count}
                    onChange={this.handleInputChange3}/></p>

                <p>P: {this.state.textRequest6_res1.p}</p>

                <p>Q: {this.state.textRequest6_res1.q}</p>

                <p>e: {this.state.textRequest6_res1.e}</p>

                <p>d: {this.state.textRequest6_res1.d}</p>

                <p>φ(n): {this.state.textRequest6_res1.fi_n}</p>

                <p>n: {this.state.textRequest6_res1.n}</p>

                <h5>Шифр исходного сообщения: {this.state.textRequest6_res1.result_1}</h5>
                <form onSubmit={this.handleSubmit1}>
                    <label>
                        <p>Исходное сообщение:</p>
                        <p><input
                            type="text"
                            value={this.state.input_text}
                            onChange={this.handleInputChange1}/></p>
                    </label>
                    <p><input type="submit" value="Зашифровать" /></p>
                </form>

                <h5>Расшифровка криптограммы: {this.state.textRequest6_res2.result_2}</h5>
                <form onSubmit={this.handleSubmit2}>
                    <label>
                        <p>Криптограмма:</p>
                        <p><input
                            type="text"
                            value={this.state.cryptogram}
                            onChange={this.handleInputChange2}/></p>
                        <p>d:</p>
                        <p><input
                            type="text"
                            value={this.state.input_d}
                            onChange={this.handleInputChange4}/></p>
                        <p>n:</p>
                        <p><input
                            type="text"
                            value={this.state.input_n}
                            onChange={this.handleInputChange5}/></p>
                    </label>
                    <p><input type="submit" value="Расшифровать" /></p>
                </form>
            </div>
        )
    }
}