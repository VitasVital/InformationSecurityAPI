import React,{Component} from 'react';

export class Caesar extends Component{
    constructor(props){
        super(props);

        this.state={
            shifr_text:'',
            rasshifr_text:'',
            shifr:'', 
            rasshifr:'',
            key:'',
            raskey:'',
            language:1,
            rashifr_language:1
        };

        this.handleSubmit1=this.handleSubmit1.bind(this);
        this.handleSubmit2=this.handleSubmit2.bind(this);
        this.handleInputChange1 = this.handleInputChange1.bind(this);
        this.handleInputChange2 = this.handleInputChange2.bind(this);
        this.handleInputChange3 = this.handleInputChange3.bind(this);
        this.handleInputChange4 = this.handleInputChange4.bind(this);
        this.handleInputChange5 = this.handleInputChange5.bind(this);
        this.handleInputChange6 = this.handleInputChange6.bind(this);
        this.handleInputChange7 = this.handleInputChange7.bind(this);
        this.handleInputChange8 = this.handleInputChange8.bind(this);
    }

    handleSubmit1(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec1',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                word: this.state.shifr,
                key: this.state.key,
                language: this.state.language,
                is_cryptogram: false
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({shifr_text:result});
        },
        (error)=>{
            alert('Failed');
        })
    }

    handleSubmit2(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'InfoSec1',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                word: this.state.rasshifr,
                key: this.state.raskey,
                language: this.state.rashifr_language,
                is_cryptogram: true
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            this.setState({rasshifr_text:result});
        },
        (error)=>{
            alert('Failed');
        })
    }


    handleInputChange1(event) {
        this.setState({shifr: event.target.value});
    }

    handleInputChange2(event) {
        this.setState({key: event.target.value});
    }

    handleInputChange3(event) {
        this.setState({rasshifr: event.target.value});
    }

    handleInputChange4(event) {
        this.setState({raskey: event.target.value});
    }

    handleInputChange5(event) {
        this.setState({language: 1});
    }

    handleInputChange6(event) {
        this.setState({language: 2});
    }

    handleInputChange7(event) {
        this.setState({rashifr_language: 1});
    }

    handleInputChange8(event) {
        this.setState({rashifr_language: 2});
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
                <h1>Шифр Цезаря</h1>
                <h2>Зашифрованный текст</h2>
                <p>{this.state.shifr_text}</p>
                <form onSubmit={this.handleSubmit1}>
                    <p>
                    <label>
                    <p>Введите текст для шифрования: </p>
                    <p><input 
                    type="text" 
                    value={this.state.shifr} 
                    onChange={this.handleInputChange1}/></p>
                    </label>
                    </p>
                    <p>
                    <label>
                    <p>Ключ:</p>
                    <p><input 
                    type="text" 
                    value={this.state.key}
                    onChange={this.handleInputChange2}/></p>
                    </label>
                    </p>
                    <label>
                    <p>Язык:</p>
                    <p>
                    <input type="radio" 
                        value={this.state.language} 
                        checked={this.state.language === 1} 
                        onChange={this.handleInputChange5} />Английский
                    </p>
                    <p>
                    <input type="radio" 
                        value={this.state.language}  
                        checked={this.state.language === 2} 
                        onChange={this.handleInputChange6} />Русский
                    </p>
                    </label>
                    <p><input type="submit" value="Зашифровать" /></p>
                </form>

                <h2>Расшифрованный текст</h2>
                <p>{this.state.rasshifr_text}</p>
                <form onSubmit={this.handleSubmit2}>
                    <label>
                    <p>Введите текст для расшифровки:</p>
                    <p><input 
                    type="text" 
                    value={this.state.rasshifr} 
                    onChange={this.handleInputChange3}/></p>
                    </label>
                    <p>
                    <label>
                    <p>Ключ:</p> 
                    <p><input 
                    type="text" 
                    value={this.state.raskey} 
                    onChange={this.handleInputChange4}/></p>
                    </label>
                    </p>
                    <label>
                    <p>Язык:</p>
                    <p>
                    <input type="radio" 
                        value={this.state.rashifr_language} 
                        checked={this.state.rashifr_language === 1} 
                        onChange={this.handleInputChange7} />Английский
                    </p>
                    <p>
                    <input type="radio" 
                        value={this.state.rashifr_language}  
                        checked={this.state.rashifr_language === 2} 
                        onChange={this.handleInputChange8} />Русский
                    </p>
                    </label>
                    <p><input type="submit" value="Расшифровать" /></p>
                </form>
            </div>
        )
    }
}