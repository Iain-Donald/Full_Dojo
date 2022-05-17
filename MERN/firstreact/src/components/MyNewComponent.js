import React, {Component} from 'react';

class MyNewComponent extends Component{
    render(){
        return (
            <div>
                <p>We are in MyNewComponent!</p>
                {this.props.someText}
            </div>
        );
    }
}

export default MyNewComponent;