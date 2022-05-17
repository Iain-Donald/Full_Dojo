import React, { useState } from "react";
import './App.css';

function App() {
  const [newTodo, setNewTodo] = useState("");
  const [todos, setTodos] = useState([]);



  const handleNewTodoSubmit = (event) => {
    event.preventDefault();

    if(newTodo.length === 0){
      return;
    }

    const todoItem = {
      text: newTodo,
      complete: false
    };


    setTodos([... todos, todoItem]);
    setNewTodo("");
  }

  const handleTodoDelete = (deleteIndex) => {
    const filteredTodos = todos.filter((todo, i) => {
      return i != deleteIndex;
    });

    setTodos(filteredTodos);
  }

  const handleToggleComplete = (idx) => {
    const updatedTodos = todos.map((todo, i) => {
      if(idx === i) {
        todo.complete = !todo.complete;
      }

      return todo;
    });
    setTodos(updatedTodos);
  }

  return (
    <div>
      <form onSubmit={(event) =>
      {
        handleNewTodoSubmit(event);
      }}>
        <input onChange={(event) => 
        {
          setNewTodo(event.target.value);
        }} type="text"
          value={newTodo}/>
        <div>
          <button>Add</button>
        </div>
      </form>

      <hr />

      {
        todos.map((todo, i) => {
          const todoClasses = [];

          if(todo.complete) {
            todoClasses.push("strike-through");
          }

          return (<div key={i}>
            <input onChange={(event) => {
              handleToggleComplete(i);
            }} checked={todo.complete} type="checkbox" />
            <span className={todoClasses.join(" ")}>{todo.text}</span>
            <button onClick={(event) => {
              handleTodoDelete(i);
            }}
            style={{marginLeft: "10px"}}>Delete</button>
            </div>
          );
        })
      }
    </div>
  );
}

export default App;
