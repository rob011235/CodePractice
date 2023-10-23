from flask import Flask
import os

app = Flask(__name__, instance_relative_config=True)

app.config.from_mapping(
    SECRET_KEY='dev',
    DATABASE=os.path.join(app.instance_path, 'flaskr.sqlite'),
)

app.config.from_pyfile('config.py', silent=True)


# ensure the instance folder exists
try:
    os.makedirs(app.instance_path)
except OSError:
    pass

#     # a simple page that says hello
@app.route('/hello')
def hello():
    return 'Hello, World!'

import db
db.init_app(app)

import auth
app.register_blueprint(auth.bp)
    
# import blog
# app.register_blueprint(blog.bp)
# app.add_url_rule('/', endpoint='index')

