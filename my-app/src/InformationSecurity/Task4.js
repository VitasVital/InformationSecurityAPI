import React,{Component} from 'react';

export class Task4 extends Component{
    constructor(props){
        super(props);

        this.state={
            a:'', 
            alpha:'',
            n:'',

            _A:'',
            _B:'',

            textRequest4_res1: {number_result:1, a:'',  alpha:'', n: '', result_1:'', _A:'', _B:'', result_2_x:'', result_2_y:'', result_2_nod:''},
            textRequest4_res2: {number_result:2, a:'',  alpha:'', n: '', result_1:'', _A:'', _B:'', result_2_x:'', result_2_y:'', result_2_nod:''}
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
        fetch(process.env.REACT_APP_API+'InfoSec4',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result:1,
                    a: this.state.a,
                    alpha: this.state.alpha,
                    n: this.state.n,
                    result_1:'',
                    _A:'',
                    _B:'',
                    result_2_x:'',
                    result_2_y:'',
                    result_2_nod:''
                }
            )
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({textRequest4_res1:result});
        },
        (error)=>{
            alert('Failed');
        })
    }

    handleSubmit2(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec4',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify(
                {
                    number_result:2,
                    a: '',
                    alpha: '',
                    n: '',
                    result_1:'',
                    _A:this.state._A,
                    _B:this.state._B,
                    result_2_x:'',
                    result_2_y:'',
                    result_2_nod:''
                }
            )
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({textRequest4_res2:result});
        },
        (error)=>{
            alert('Failed');
        })
    }


    handleInputChange1(event) {
        this.setState({a: event.target.value});
    }

    handleInputChange2(event) {
        this.setState({alpha: event.target.value});
    }

    handleInputChange3(event) {
        this.setState({n: event.target.value});
    }

    handleInputChange4(event) {
        this.setState({_A: event.target.value});
    }

    handleInputChange5(event) {
        this.setState({_B: event.target.value});
    }

    componentDidMount(){
        //this.refreshList('qwrtr', 3);
        //this.checkCookie();
    }

    componentDidUpdate(){
        //this.refreshList('qwrtr', 3);
        //this.checkCookie();
    }
    render(){
        return(
            <div className="container">
                <h1>Возведение в степень по модулю</h1>
                <h5>Результат возведения по модулю: {this.state.textRequest4_res1.result_1}</h5>
                <form onSubmit={this.handleSubmit1}>
                    <p>
                    <label>
                    <p>Введите a: </p>
                    <p><input 
                    type="text" 
                    value={this.state.a} 
                    onChange={this.handleInputChange1}/></p>
                    </label>
                    </p>
                    <p>
                    <label>
                    <p>Введите alpha:</p>
                    <p><input 
                    type="text" 
                    value={this.state.alpha}
                    onChange={this.handleInputChange2}/></p>
                    </label>
                    </p>
                    <p>
                    <label>
                    <p>Введите n:</p>
                    <p><input 
                    type="text" 
                    value={this.state.n}
                    onChange={this.handleInputChange3}/></p>
                    </label>
                    </p>
                    <p><input type="submit" value="Отправить" /></p>
                </form>

                <h1>Расширенный алгоритм Евклида</h1>
                <h5>Результат x: {this.state.textRequest4_res2.result_2_x}</h5>
                <h5>Результат y: {this.state.textRequest4_res2.result_2_y}</h5>
                <h5>Результат НОД(А, В): {this.state.textRequest4_res2.result_2_nod}</h5>
                <form onSubmit={this.handleSubmit2}>
                    <label>
                    <p>Введите A:</p>
                    <p><input 
                    type="text" 
                    value={this.state._A} 
                    onChange={this.handleInputChange4}/></p>
                    </label>
                    <p>
                    <label>
                    <p>Введите В:</p> 
                    <p><input 
                    type="text" 
                    value={this.state._B} 
                    onChange={this.handleInputChange5}/></p>
                    </label>
                    </p>
                    <p><input type="submit" value="Отправить" /></p>
                </form>
            </div>
        )
    }
}