import React, { Component } from 'react';
import axios from 'axios';
import "../src/style.css"
import MainPage from '../src/pages/templates';

class App extends Component {
  constructor(props){
  super(props);
  this.state = {
    data: [],
    id: 0,
    userName:'1',
    password:null,
    repeatpassword:null,
    goToMainPage :false,
    showSignUp :false
  }

  };

  authenticateAccount = (userName, password) => {
    let loggedInSuccess = false;
    fetch('http://localhost:3000/api/authenticate')
      .then((data) => 
        data.json()
      )
      .then((res) => {
var data = res.data
        data.forEach(function(item){
          if(item.userName===userName&&item.password===password){
      //      console.log('item.username: '+item.userName+', username:'+userName)
      //      console.log('item.pass:'+item.password+', pass: '+password)
           loggedInSuccess = true;
          }
        })
        this.setState({
          goToMainPage:loggedInSuccess
        })
      //  console.log(this.state.goToMainPage)
        }
        )
        
  };

  showSignUpPage=()=>{
    this.setState({
      showSignUp:true
    })
  }

  hideSighUpPage=()=>{
    this.setState({
      showSignUp:false
    })
  }

  signupAccount = (iuserName, password,repeatpassword) => {
    let accountAlreadyExist = false;
    fetch('http://localhost:3000/api/authenticate')
      .then((data) => 
        data.json()
      )
      .then((res) => {
var data = res.data
console.log(data)
        data.forEach(function(item){
          if(item.userName===iuserName){
            accountAlreadyExist=true;
          }
        });

        console.log(accountAlreadyExist)

          if(!accountAlreadyExist&&iuserName!=null&&password===repeatpassword&&password!=null){
            axios.post('http://localhost:3001/api/signup', {
              userName : iuserName,
              password:password,
            });
            console.log("account created")
        }else{
          console.log("account was not created.")
        }
        }   
      )
  };

  render() {

    if(this.state.goToMainPage){

     document.body.style.backgroundImage= "url('/img/write-593333_1920.jpg')";
      return (

  <MainPage />

    )
    }else if(this.state.showSignUp){
return(
  <div className = "login-and-signup-container" onMouseLeave={this.hideSighUpPage}>
      <div className="login-container">
        <form action="#">
          <input type="email" placeholder="Email" onChange={(e) => this.setState({ userName: e.target.value })}/>
          <input type="password" placeholder="Password" onChange={(e) => this.setState({ password: e.target.value })}/>
          <input type="password" placeholder="Repeat password" onChange={(e)=>this.setState({repeatpassword:e.target.value})}/>
        </form>
      </div>
      <div className="sign-up-container" onMouseEnter={this.showSignUpPage}>
        <div className="overlay">
          <div className="overlay-panel overlay-right">
            <h1>Would you like to become our new member?</h1>
            <p>(〃'▽'〃)</p>
            <button id="signUp" onClick={() =>
              this.signupAccount(this.state.userName, this.state.password,this.state.repeatpassword)
            }>Sign Up</button>
          </div>
        </div>
      </div>
      </div>
)
    }
    else{
    return (
<div className = "login-and-signup-container">
      <div className="login-container">
        <form action="#">
          <h1>Sign in</h1>
          <div className="social-container">
           <a href="#" className="social"><i className="fab fa-facebook-f" ></i></a>
            <a href="#" className="social"><i className="fab fa-linkedin-in"></i></a>
            <a href="#" className="social"><i className="fab fa-git"></i></a>
          </div>
          <span>Or</span>
          <input type="email" placeholder="Email" onChange={(e) => this.setState({ userName: e.target.value })}/>
          <input type="password" placeholder="Password" onChange={(e) => this.setState({ password: e.target.value })}/>
          <a href="#" id="forgotpassword">Forgot your password?</a>
          <button id="signIn" onClick={() =>
              this.authenticateAccount(this.state.userName, this.state.password)
            }>Sign In</button>
        </form>
      </div>
      <div className="sign-up-container" onMouseEnter={this.showSignUpPage}>
        <div className="overlay">
          <div className="overlay-panel overlay-right">
            <h1>Would you like to become our new member?</h1>
            <p>(〃'▽'〃)</p>
            <button id="signUp">Sign Up</button>
          </div>
        </div>
      </div>
      </div>
    )}}};

export default App;