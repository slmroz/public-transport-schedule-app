import React from 'react';

class Footer extends React.Component {
  render() {
    return (
        <footer className="footer mt-auto py-3">
          <div className="container">
            <span className="text-muted">2019 Slawek Mroz</span>
          </div>
        </footer>
    );
  }
}

Footer.defaultProps = {
};

export default Footer;