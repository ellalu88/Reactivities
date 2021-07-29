import React, { useEffect } from "react";
import logo from "./logo.svg";
import "./App.css";
import axios from 'axios';
import { Header, List } from "semantic-ui-react";

function App() {

  const[activities,setActivities]= useState([]);

  useEffect(()=>{
    axios.get('http://localhost:5000/api/activities').then(response=>{
      console.log(response);
      setActivities(response.data);
    })
  },[])

 

  return (
    <div >
      <Header as='h2' icon='users' content='Reactivities'/>
      <header className="App-header">
        

        <list>
        {
            activities.map(activity:any=>(
              <List.Item key={activity.id}>
                {activity.title}
              </List.Item>
            ))
          }
        </list>
          
        
      </header>
    </div>
  );
}

export default App;
