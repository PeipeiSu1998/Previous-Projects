
import React from "react";
import {Button} from "react-bootstrap"

const MainPage = () => {
    return (   
      <div className='templates-container'>
        <nav className="navbar navbar-expand-lg navbar-light bg-light">

  <div className="collapse navbar-collapse" id="navbarSupportedContent">
    <li className="nav-item dropdown mx-auto my-2 order-0 order-md-1 position-relative">
        <a className="nav-link dropdown-toggle " href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
        <i className="fas fa-user" />
        </a>
        <div className="dropdown-menu" aria-labelledby="navbarDropdown">
          <a className="dropdown-item" href="/">Log Out</a>
        </div>
      </li>
  </div>
</nav>

        
      <div >
        <br></br>
        <h1 className='chooseTemplateText col-md-12 col-sm-12'>&#127774; Choose your favorite template:</h1>
    <a href="/coldblue.html"><img src="/img/coldblue.png" width="300" alt ="img" className="col-md-4 col-sm-12 templateButtons"/></a>
    <a href="/cutepink.html"><img src="/img/cutepink.png" width="300" alt ="img" className="col-md-4 col-sm-12 templateButtons"/></a>
    <a href="/simpleblack.html"><img src="/img/simpleblack.png" width="300" alt ="img" className="col-md-4 col-sm-12 templateButtons"/></a>
      </div>
      </div>
    );
  };
  
  export default MainPage;

